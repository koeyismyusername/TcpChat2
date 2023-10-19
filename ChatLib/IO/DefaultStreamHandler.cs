using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatLib.IO
{
    public class DefaultStreamHandler : IStreamHandler
    {
        public async Task<(bool isClosed, T? content)> ReadAsync<T>(Stream stream)
        {
            byte[] contentLengthBytes = new byte[4];
            int read = await stream.ReadAsync(contentLengthBytes);
            if (read is 0)
            {
                stream.Close();
                return (true, default(T));
            }

            byte[] contentByte = new byte[BitConverter.ToInt32(contentLengthBytes)];
            await stream.ReadAsync(contentByte);
            
            string json = Encoding.UTF8.GetString(contentByte);
            return (false, JsonSerializer.Deserialize<T>(json));
        }

        public async Task WriteAsync(Stream stream, object content)
        {
            string json = JsonSerializer.Serialize(content);
            byte[] contentBytes = Encoding.UTF8.GetBytes(json);
            byte[] contentLengthBytes = BitConverter.GetBytes(contentBytes.Length);

            await stream.WriteAsync(contentLengthBytes.Concat(contentBytes).ToArray());
        }
    }
}
