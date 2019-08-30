/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    public interface IStateChangeRule
    {
        bool IsCanChangeState(IState current, IState next);
    }
}
