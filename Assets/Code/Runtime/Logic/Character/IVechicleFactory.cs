using System.Threading.Tasks;
using Zenject;

namespace Assets.Code.Runtime.Logic.Character
{
    public interface IVechicleFactory
    {
        Task<Vehicle> Create();
    }
}