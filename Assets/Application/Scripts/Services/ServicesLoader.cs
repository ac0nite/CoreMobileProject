using Cysharp.Threading.Tasks;

namespace Application.Scripts.Services
{
    public interface IServicesLoader
    {
        UniTask Loading();
    }
    public class ServicesLoader : IServicesLoader
    {
        public async UniTask Loading()
        {
            await UniTask.DelayFrame(1);
            Log.Debug(Prefix.Service, "SERVICES LOADED DEBUG");
        }
    }
}