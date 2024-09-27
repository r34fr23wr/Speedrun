using Zenject;

namespace Source.Gameplay.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharacterInput>()
                .AsSingle();
        }
    }
}
