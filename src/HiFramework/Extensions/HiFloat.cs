/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;

namespace HiFramework
{
    /// <summary>
    /// 新float类型,自动保留Length位小数
    /// </summary>
    [Serializable]
    public struct HiFloat
    {
        public static int Length = 2;

        private float _value;

        private HiFloat(float value)
        {
            _value = (float)Math.Round(value, Length);
        }

        public static implicit operator HiFloat(float value)
        {
            return new HiFloat(value);
        }

        public static bool operator ==(HiFloat left, HiFloat right)
        {
            return left._value == right._value;
        }

        public static bool operator !=(HiFloat left, HiFloat right)
        {
            return left._value != right._value;
        }

        public static bool operator <(HiFloat left, HiFloat right)
        {
            return left._value < right._value;
        }

        public static bool operator >(HiFloat left, HiFloat right)
        {
            return left._value > right._value;
        }

        public static bool operator <=(HiFloat left, HiFloat right)
        {
            return left._value <= right._value;
        }

        public static bool operator >=(HiFloat left, HiFloat right)
        {
            return left._value >= right._value;
        }

        public static HiFloat operator ++(HiFloat value)
        {
            return ++value._value;
        }

        public static HiFloat operator --(HiFloat value)
        {
            return --value._value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HiFloat))
            {
                return false;
            }
            var other = (HiFloat)obj;
            return _value == other._value;
        }
    }
}