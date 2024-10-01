using Zenject;
using UnityEngine;
using Source.Gameplay.Common;

namespace Source.Gameplay.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField] private Trashcan _trashcan;

        public override void InstallBindings()
        {
            Container.Bind<Trashcan>()
                .FromInstance(_trashcan)
                .AsSingle();
        }
    }
}
