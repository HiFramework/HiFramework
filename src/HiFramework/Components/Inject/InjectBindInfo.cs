/***************************************************************
 * Description: 
 *
 * Documents: 
 * Author: hiramtan@live.com
***************************************************************/

using System;

namespace HiFramework
{
    /// <summary>
    /// 绑定信息
    /// </summary>
    public class InjectBindInfo
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// 实例
        /// </summary>
        public object Obj { get; private set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string AsName { get; private set; }

        /// <summary>
        /// 设置类型
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(string key)
        {
            Key = key;
        }

        /// <summary>
        /// 设置实例
        /// </summary>
        /// <param name="obj"></param>
        public void SetObject(object obj)
        {
            Obj = obj;
        }

        /// <summary>
        /// 设置别名
        /// </summary>
        /// <param name="asName"></param>
        public void SetAsName(string asName)
        {
            AsName = asName;
        }
    }
}
