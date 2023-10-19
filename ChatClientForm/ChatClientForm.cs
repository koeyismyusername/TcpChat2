using ChatClientForm.Models;
using ChatClientForm.Types;
using ChatLib.IO;
using System.Net;
using System.Net.Sockets;

namespace ChatClientForm
{
    public partial class ChatClientForm : Form
    {
        private TcpClient? _tcpClient;
        private IStreamHandler _streamHandler;

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            private set
            {
                _isRunning = value;
                btnConnect.Enabled = !value;
                btnDisconnect.Enabled = value;
                btnSend.Enabled = value;
                numRoomId.Enabled = !value;
                tBoxUsername.Enabled = !value;
            }
        }

        public long RoomId { get => (long)numRoomId.Value; }
        public string Username { get => tBoxUsername.Text; }
        public string Message { get => tBoxMessage.Text; }

        public ChatClientForm()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Ŭ���̾�Ʈ�� ������ �����մϴ�.
        /// </summary>
        /// <param name="iPAddress">IP�ּ�</param>
        /// <param name="port">��Ʈ��ȣ</param>
        /// <returns>���ῡ �����ϸ� true, �����ϸ� false</returns>
        private async Task<bool> ConnectClientAsync(IPAddress iPAddress, int port)
        {
            bool isConnected = false;

            _tcpClient?.Dispose();
            _tcpClient = new TcpClient();

            try
            {
                await _tcpClient.ConnectAsync(iPAddress, port);
                isConnected = true;
            }
            catch (SocketException e)
            {
                lBoxMessages.Items.Add("������ �غ���� �ʾҽ��ϴ�.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"���� ���� �� ���� �߻�: {e.Message}");
            }

            if (!isConnected)
            {
                _tcpClient.Dispose();
                _tcpClient = null;
            }

            return isConnected;
        }

        private void DisConnectClient()
        {

        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            lBoxMessages.Items.Clear();

            IsRunning = await ConnectClientAsync(IPAddress.Parse("127.0.0.1"), 8080);
            if (!IsRunning) return;

            _ = HandleClientAsync();
        }

        private async Task HandleClientAsync()
        {
            while (IsRunning)
            {
                (bool isClosed, Chat? chat) = await _streamHandler.ReadAsync<Chat>(_tcpClient!.GetStream());
                if (isClosed) break;

                if (chat is null) continue;

                DrawMessage(chat);
            }
        }

        private void DrawMessage(Chat chat)
        {
            switch (chat.state)
            {
                case ChatState.Connect:
                    lBoxMessages.Items.Add($"{chat.username}���� �����߽��ϴ�.");
                    break;

                case ChatState.Message:
                    lBoxMessages.Items.Add($"{chat.username}: {chat.message}");
                    break;

                case ChatState.Close:
                    lBoxMessages.Items.Add($"{chat.username}���� �������ϴ�.");
                    break;

                default:
                    break;
            }
        }

        private void BtnDisConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void tBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}