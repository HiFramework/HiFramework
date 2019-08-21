/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
namespace HiFramework
{
    public interface ISignal
    {
        T GetSignal<T>() where T : class;
        void RemoveSignal<T>() where T : class;
    }
}


//public class AddGold : Signal<int>
//{

//}

//void Test()
//{
//    var signalComponent = Center.Get<ISignal>();
//    var signal = signalComponent.GetSignal<AddGold>();
//    signal.AddListener((int gold) => { });

//    signal = signalComponent.GetSignal<AddGold>();
//    signal.Fire(100);
//}
