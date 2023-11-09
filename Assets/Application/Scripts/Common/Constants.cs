using Application.SceneLoader;
using UnityEngine.SceneManagement;

namespace Resources
{
    public static partial class Constants
    {
        public static SceneRequest GameplaySceneRequest = new SceneRequest()
        {
            Name = "Gameplay",
            LoadMode = LoadSceneMode.Additive,
            UnloadOptions = UnloadSceneOptions.None
        };

        public class ID
        {
            public const string ApplicationCanvas = "ApplicationCanvas";
            public const string GameplayCanvas = "GameplayCanvas";
        }

        public class Resources
        {
            public const string SplashScreen = "Application/SplashScreen";
            public const string LoadingScreen = "Application/LoadingScreen";
            // public const string PreviewScreen = "Prefabs/Gameplay/UI/PreviewScreen";
            // public const string GameplayScreen = "Prefabs/Gameplay/UI/GameplayScreen";
            // public const string ResultScreen = "Prefabs/Gameplay/UI/ResultScreen";
        }
    }
}