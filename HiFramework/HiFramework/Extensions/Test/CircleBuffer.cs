using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework.Extensions.Test
{
    class CircleBuffer<T>:ICircleBuffer<T>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T[] Buffer { get; }
        public int Capacity { get; }
        public int BlockSize {
            get { return _blockSize; }
            set { _blockSize = value; }
        }
        public int HowManyCanRead { get; }
        public int HowManyCanWrite { get; }
        public int ReadPosition { get; }
        public int WritePosition { get; }


        private int _blockSize = 1024;

        public CircleBuffer(int size)
        {

        }

        public void MoveReadPosition(int size)
        {
            throw new NotImplementedException();
        }

        public void MoveWritePosition(int size)
        {
            throw new NotImplementedException();
        }

        public byte[] Read(int length)
        {
            throw new NotImplementedException();
        }

        public void Read(byte[] toArray, int index, int length)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] sourceArray, int index, int length)
        {
            throw new NotImplementedException();
        }
    }
}
