using ChatLib.IO;
using ChatServerForm.Models;
using ChatServerForm.Types;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ChatServerForm
{
    public partial class ChatServerForm : Form
    {
        private TcpListener _listener;
        private IStreamHandler _streamHandler;
        private Dictionary<long, List<TcpClient>> _roomDict;

        private bool _isRunning;
        public bool IsRunning 
        { 
            get => _isRunning;
            private set
            {
                _isRunning = value;
                btnStart.Enabled = !value;
                btnExit.Enabled = value;
            } 
        }
        public ChatServerForm()
        {
            InitializeComponent();
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            _streamHandler = new DefaultStreamHandler();
            _roomDict = new Dictionary<long, List<TcpClient>>();

            IsRunning = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lBoxClients.Items.Clear();
            lBoxMessages.Items.Clear();
            _roomDict.Clear();

            StartServer();
            lBoxMessages.Items.Add("서버가 준비되었습니다.");

            _ = HandleClientsAsync();
        }

        private void StartServer()
        {
            if (IsRunning) return;

            _listener.Start();
            IsRunning = true;
        }

        private async Task HandleClientsAsync()
        {
            try
            {
                while (true)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();

                    _ = Listen(client);
                }
            } catch (SocketException e)
            {
                Debug.Print("서버가 종료되었습니다.");
            }
        }

        private async Task Listen(TcpClient client)
        {
            while(true)
            {
                (bool isClosed, Chat? chat) = await _streamHandler.ReadAsync<Chat>(client.GetStream());
                if (isClosed) break;

                if (chat is null) continue;

                Route(chat, client);
            }
        }

        private void Route(Chat chat, TcpClient client)
        {
            long key = chat.roomId;

            switch (chat.state)
            {
                case ChatState.Connect:
                    AddClient(key, client);
                    SendToRoom(key, chat);
                    lBoxMessages.Items.Add($"{chat.username}님이 입장했습니다.");
                    lBoxClients.Items.Add(chat.username);
                    break;

                case ChatState.Message:
                    SendToRoom(key, chat);
                    lBoxMessages.Items.Add($"{chat.username}: {chat.message}");
                    break;

                case ChatState.Close:
                    RemoveClient(key, client);
                    SendToRoom(key, chat);
                    lBoxMessages.Items.Add($"{chat.username}님이 나갔습니다.");
                    lBoxClients.Items.Remove(chat.username);
                    break;

                default:
                    break;
            }
        }

        private void AddClient(long key, TcpClient client)
        {
            _roomDict.TryGetValue(key, out List<TcpClient>? clients);

            if (clients is null) _roomDict.Add(key, new List<TcpClient> { client });
            else _roomDict[key].Add(client);
        }

        private void RemoveClient(long key, TcpClient client)
        {
            _roomDict.TryGetValue(key, out List<TcpClient>? clients);

            clients?.Remove(client);
        }

        private void SendToRoom(long key, Chat chat)
        {
            _roomDict.TryGetValue(key, out List<TcpClient>? clients);

            clients?.ForEach( c => _streamHandler.WriteAsync(c.GetStream(), chat));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            StopServer();
            lBoxMessages.Items.Add("서버가 종료되었습니다.");
        }

        private void StopServer()
        {
            IsRunning = false;
            _listener.Stop();
            
            foreach (var room in _roomDict.Values)
            {
                room?.ForEach(c => c.GetStream().Close());
            }
        }
    }
}