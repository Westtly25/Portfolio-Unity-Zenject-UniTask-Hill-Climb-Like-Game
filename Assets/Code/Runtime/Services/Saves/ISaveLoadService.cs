using System.Threading.Tasks;

namespace Assets.Code.Runtime.Services.Saves
{
    public interface ISaveLoadService
    {
        Task Load();
        Task Save();
    }
}