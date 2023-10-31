using System;
using Application.Scripts.Services;
using Application.StateMachine;
using Application.StateMachine.States;
using Application.UI.Common;
using Common.StateMachine;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Application.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("ProjectContextInstaller");
            InstallStateMachine();
            InstallSignals();
            InstallLoader();
            InstallUI();
            InitialiseDOTween();
            InstallServices();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<ServicesLoader>().AsSingle();
        }

        private void InitialiseDOTween()
        {
            DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(500, 50);
        }

        private void InstallUI()
        {
            Container.BindInterfacesAndSelfTo<ScreenController>().AsSingle();
        }

        private void InstallLoader()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader.SceneLoader>().AsSingle();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<ApplicationStateMachine.Signals.NextState>().OptionalSubscriber();
        }
        private void InstallStateMachine()
        {
            Container.Bind(typeof(ApplicationStateMachine), typeof(IDisposable)).To<ApplicationStateMachine>().AsSingle().NonLazy();

            Container.BindFactory<IState, LoadingApplicationState.Factory>()
                .To<LoadingApplicationState>()
                .WhenInjectedInto<ApplicationStateMachine>();
        
            Container.BindFactory<IState, GameplayApplicationState.Factory>()
                .To<GameplayApplicationState>()
                .WhenInjectedInto<ApplicationStateMachine>();
        }
    }
}