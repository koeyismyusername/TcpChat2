using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.IO
{
    public interface IStreamHandler
    {
        /// <summary>
        /// 비동기적으로 주어진 Stream에서 T타입의 데이터를 읽습니다.
        /// Stream이 비어있는 경우 isEmpty는 true입니다.
        /// </summary>
        /// <typeparam name="T">읽을 데이터 타입</typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        Task<(bool isEmpty, T? content)> ReadAsync<T>(Stream stream);
        /// <summary>
        /// 비동기적으로 주어진 content를 stream을 통해 보냅니다.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<bool> WriteAsync(Stream stream, object content);
    }
}
