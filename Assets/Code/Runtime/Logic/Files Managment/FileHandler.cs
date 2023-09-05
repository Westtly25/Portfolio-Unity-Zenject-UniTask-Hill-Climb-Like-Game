using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Runtime.Logic
{
    public sealed class FileHandler : IFileHandler
    {
        public async Task<string> ReadAsync(string path)
        {
            try
            {
                using FileStream sourceStream = new(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
                using StreamReader reader = new(sourceStream);
                StringBuilder sb = new();

                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    sb.AppendLine(line);
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Directory.CreateDirectory(path);
            }

            return string.Empty;
        }

        public async Task WriteAsync(string path, string data)
        {
            using FileStream destinationStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            using StreamWriter writer = new(destinationStream);
            await writer.WriteLineAsync(data);
        }
    }
}