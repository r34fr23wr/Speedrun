using Zenject;

namespace Source.Boot
{
    public class BootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BootService>()
                .AsSingle();
        }
    }
}
