/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/
using HiFramework.Core;
namespace HiFramework
{
    public class Binder:Core.Binder
    {
        public override void Init()
        {
            base.Init();
            Bind<ISignalComponent>().To<SignalComponent>();
            Bind<IEventComponent>().To<EventComponent>();
            Bind<IIOComponent>().To<IOComponent>();
            Bind<IInjectComponent>().To<InjectComponent>();
            Bind<IObjectManager>().To<ObjectsManager>();
        }
    }
}
