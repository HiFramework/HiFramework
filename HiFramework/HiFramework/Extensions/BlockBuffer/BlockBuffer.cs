/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using HiFramework.Assert;
using System;

namespace HiFramework
{
    public class BlockBuffer<T> : IBlockBuffer<T>
    {
        public T[] Buffer { get; private set; }
        public int Size
        {
            get { return Buffer.Length; }
        }
        public int BlockSize
        {
            get { return _blockSize; }
            set { _blockSize = value; }
        }
        public int ReadPosition { get; private set; }
        public int WritePosition { get; private set; }
        private int _blockSize = 1 << 10;

        private EState State
        {
            get
            {
                if (ReadPosition > WritePosition)
                    return EState.ReadAhead;
                if (ReadPosition < WritePosition)
                    return EState.WriteAhead;
                return EState.ReadWriteAreEqual;
            }
        }

        public BlockBuffer(int size = 1 << 10)
        {
            Buffer = new T[size];
        }

        public BlockBuffer(T[] buffer)
        {
            Buffer = buffer;
        }

        public void MoveReadPostion(int length)
        {
            AssertThat.IsTrue(ReadPosition + length <= Size);
            ReadPosition += length;
        }

        public void MoveWritePosition(int length)
        {
            AssertThat.IsTrue(WritePosition + length <= Size);
            WritePosition += length;
        }

        public void MoveReadPositionTo(int index)
        {
            AssertThat.IsTrue(index < Size);
            ReadPosition = index;
        }

        public void MoveWritePostionTo(int index)
        {
            AssertThat.IsTrue(index < Size);
            WritePosition = index;
        }

        public T[] Read(int length)
        {
            T[] array = new T[length];
            Read(array, 0, length);
            return array;
        }

        public void Read(T[] destinationArray, int destinationIndex, int length)
        {
            AssertThat.IsTrue(ReadPosition + length <= Size);
            AssertThat.IsTrue(destinationIndex + length <= destinationArray.Length);
            System.Buffer.BlockCopy(Buffer, ReadPosition, destinationArray, destinationIndex, length);
            ReadPosition += length;
        }

        public void Write(T[] sourceArray)
        {
            Write(sourceArray, 0, sourceArray.Length);
        }

        public void Write(T[] sourceArray, int sourceIndex, int length)
        {
            var targetLength = WritePosition + length;
            if (Size >= targetLength)
            {
                System.Buffer.BlockCopy(sourceArray, sourceIndex, Buffer, WritePosition, length);
                WritePosition += length;
            }
            else
            {
                var needCount = sourceArray.Length / BlockSize;
                var remainNeedCount = sourceArray.Length % BlockSize;
                var allReadyWriteInCount = WritePosition + 1;
                var remainCanWriteCount = Size - allReadyWriteInCount;
                if (remainCanWriteCount >= remainNeedCount)
                {
                    //Can write in 
                }
                else
                {
                    needCount += 1;
                }
                var blockSize = needCount * BlockSize;
                var newArray = new T[Size + blockSize];
                System.Buffer.BlockCopy(Buffer, ReadPosition, newArray, 0, WritePosition - ReadPosition);
                System.Buffer.BlockCopy(sourceArray, sourceIndex, newArray, WritePosition - ReadPosition, length);
                WritePosition = WritePosition - ReadPosition + length;
                Buffer = newArray;
            }
        }

        public void ResetIndex()
        {
            switch (State)
            {
                case EState.ReadWriteAreEqual:
                    ReadPosition = WritePosition = 0;
                    break;
                case EState.WriteAhead:
                    var length = WritePosition - ReadPosition;
                    for (int i = 0; i < length; i++)
                    {
                        Buffer[i] = Buffer[ReadPosition + i];
                    }
                    ReadPosition = 0;
                    WritePosition = length;
                    break;
                case EState.ReadAhead:
                    AssertThat.Fail("Read and write position error");
                    break;
            }
        }

        public void Dispose()
        {
            Buffer = null;
        }

        enum EState
        {
            ReadAhead,
            WriteAhead,
            ReadWriteAreEqual
        }
    }
}
