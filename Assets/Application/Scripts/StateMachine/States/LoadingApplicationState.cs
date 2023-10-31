using Application.Scripts.Services;
using Application.UI;
using Application.UI.Common;
using Common.StateMachine;
using Zenject;

namespace Application.StateMachine.States
{
    public class LoadingApplicationState : IState
    {
        private readonly IScreenController _screenController;
        private readonly IServicesLoader _servicesLoaderLoader;
        private readonly SignalBus _signals;

        public LoadingApplicationState(
            SignalBus signalBus,
            IScreenController screenController,
            IServicesLoader servicesLoaderLoader)
        {
            _signals = signalBus;
            _screenController = screenController;
            _servicesLoaderLoader = servicesLoaderLoader;
        }
        public async void OnEnter()
        {
            _screenController.Show(GameplayScreenType.SPLASH);
            await _servicesLoaderLoader.Loading();
            _signals.TryFire(new ApplicationStateMachine.Signals.NextState(ApplicationStateEnum.GAMEPLAY));
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