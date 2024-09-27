using Zenject;
using UnityEngine;
using Source.Services.SaveLoad;
using Source.Services.Score;
using Source.Services.Player;
using Source.Services;

namespace Source.Boot
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveLoadService>()
                .To<PlayerPrefsSaveLoadService>()
                .AsSingle();

            Container.Bind<IScoreService>()
                .To<ScoreService>()
                .AsSingle();

            Container.Bind<IPlayerService>()
                .To<PlayerService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<LoginService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle();
        }
    }
}