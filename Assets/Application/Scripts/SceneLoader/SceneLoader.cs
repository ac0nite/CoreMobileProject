using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Application.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(SceneRequest sceneRequest)
        {
            Log.Debug(Prefix.Scene, $"{sceneRequest.Name} LOAD");
            await SceneManager.LoadSceneAsync(sceneRequest.Name, sceneRequest.LoadMode).ToUniTask();
        }

        public async UniTask UnLoadSceneAsync(SceneRequest sceneRequest)
        {
            Log.Debug(Prefix.Scene, $"{sceneRequest.Name} UNLOAD");
            await SceneManager.UnloadSceneAsync(sceneRequest.Name, sceneRequest.UnloadOptions).ToUniTask();
        }
    }
}
