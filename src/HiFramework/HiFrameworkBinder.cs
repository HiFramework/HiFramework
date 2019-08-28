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
            Bind<IIO>().To<IOComponent>();
            Bind<IInject>().To<InjectComponent>();
        }
    }
}
