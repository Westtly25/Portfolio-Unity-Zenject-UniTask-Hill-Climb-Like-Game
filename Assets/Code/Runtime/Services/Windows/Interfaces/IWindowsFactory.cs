using System.Threading.Tasks;

namespace Assets.Code.Runtime.Services.Windows
{
    public interface IWindowsFactory
    {
        Task<Window> Create(string address);
    }
}