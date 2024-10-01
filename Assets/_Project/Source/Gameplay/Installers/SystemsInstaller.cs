using Zenject;
using Source.Gameplay.Systems;

namespace Source.Gameplay.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplayStateObserver>()
                .AsSingle();
        }
    }
}
