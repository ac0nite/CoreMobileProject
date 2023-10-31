using Cysharp.Threading.Tasks;
using UnityEngine;

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
            Debug.Log("SERVICES LOADED");
        }
    }
}