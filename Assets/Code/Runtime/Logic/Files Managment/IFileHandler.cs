using System.Threading.Tasks;

namespace Assets.Code.Runtime.Logic
{
    public interface IFileHandler
    {
        Task<string> ReadAsync(string path);
        Task WriteAsync(string path, string data);
    }
}
