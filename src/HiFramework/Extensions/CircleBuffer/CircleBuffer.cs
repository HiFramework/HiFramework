/****************************************************************************
 * Description:Circle buffer is fixed size and reuse
 *
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework
{
    public class CircleBuffer<T> : ICircleBuffer<T>
    {
        public T[] Buffer { get; private set; }
        public int Capacity { get; }
        public int ReadPosition { get; private set; }
        public int WritePosition { get; private set; }

        public CircleBuffer(int capacity = 1 << 10)
        {
            Capacity = capacity;
            Buffer = new T[capacity];
        }

        public void MoveReadPostion(int length)
        {
            ReadPosition += length;
            var numb = ReadPosition / Capacity;
            ReadPosition -= numb * Capacity;
        }

        public void MoveWritePosition(int length)
        {
            WritePosition += length;
            var numb = WritePosition / Capacity;
            WritePosition -= numb * Capacity;
        }

        public void MoveReadPositionTo(int index)
        {
            Assert.IsTrue(index < Capacity);
            ReadPosition = index;
        }

        public void MoveWritePostionTo(int index)
        {
            Assert.IsTrue(index < Capacity);
            WritePosition = index;
        }

        public T[] Read(int length)
        {
            T[] buffer = new T[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = Buffer[ReadPosition];
                MoveReadPostion(1);
            }
            return buffer;
        }

        public void Read(T[] destinationArray, int destinationIndex, int length)
        {
            for (int i = destinationIndex; i < length; i++)
            {
                destinationArray[i] = Buffer[ReadPosition];
                MoveReadPostion(1);
            }
        }

        public void Write(T[] sourceArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                Buffer[WritePosition] = sourceArray[i];
                MoveWritePosition(1);
            }
        }

        public void Write(T[] sourceArray, int sourceIndex, int length)
        {
            for (int i = sourceIndex; i < length; i++)
            {
                Buffer[WritePosition] = sourceArray[i];
                MoveWritePosition(1);
            }
        }
        public void Dispose()
        {
            Buffer = null;
        }
    }
}