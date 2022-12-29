using Zenject;

namespace src.Mechanic
{
    public class BootStraper : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EventHolder>().FromNew().AsSingle().NonLazy();
            Container.Bind<StackHolder>().FromNew().AsSingle().NonLazy();
        }
    }
}
