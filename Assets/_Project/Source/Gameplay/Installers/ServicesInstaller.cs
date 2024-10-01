using Zenject;
using Source.Services.Timer;
using Source.Services;

namespace Source.Gameplay.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterInput>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<TimerService>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<GameReloadService>()
                .AsSingle();
        }
    }
}
