using Zenject;

namespace Source.MainMenu.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerInputInMenu>()
                .AsSingle();
        }
    }
}
