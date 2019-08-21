/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/
namespace HiFramework
{
    public class HiFrameworkBinder : Binder
    {
        public override void Init()
        {
            Bind<ISignal>().To<SignalComponent>();
            Bind<IEvent>().To<EventComponent>();
            Bind<IIOComponent>().To<IOComponent>();
            Bind<IInjectComponent>().To<InjectComponent>();
            Bind<IObjectManager>().To<ObjectsManager>();
        }
    }
}
