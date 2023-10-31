using Application.SceneLoader;
using Application.UI.Common;
using Common.StateMachine;
using Cysharp.Threading.Tasks;
using Resources;
using UnityEngine;
using Zenject;

namespace Application.StateMachine.States
{
    public class GameplayApplicationState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IScreenController _screenController;

        public GameplayApplicationState(
            ISceneLoader sceneLoader,
            IScreenController screenController)
        {
            _sceneLoader = sceneLoader;
            _screenController = screenController;
        }
        public async void OnEnter()
        {
            await _sceneLoader.LoadSceneAsync(Constants.GameplaySceneRequest);
            Debug.Log($"SCENE '{Constants.GameplaySceneRequest.Name}' LOADED");
        }

        public void OnExit()
        {
        }
        
        #region FACTORY

        public class Factory : PlaceholderFactory<IState>
        {
        }

        #endregion
    }
}