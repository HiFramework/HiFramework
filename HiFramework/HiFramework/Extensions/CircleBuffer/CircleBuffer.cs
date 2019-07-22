/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using HiFramework.Assert;
using System;

namespace HiFramework
{
    public class CirleBuffer<T> : ICircleBuffer<T>
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

        public CirleBuffer(int size = 1 << 10)
        {
            Buffer = new T[size];
        }

        public void MoveReadPostion(int length)
        {
            AssertThat.IsTrue(ReadPosition + length < Size);
            ReadPosition += length;
        }

        public void MoveWritePosition(int length)
        {
            AssertThat.IsTrue(WritePosition + length < Size);
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
            AssertThat.IsTrue(ReadPosition + length < Size);
            T[] array = new T[length];
            Array.Copy(Buffer, ReadPosition, array, 0, length);
            ReadPosition += length;
            return array;
        }

        public void Read(T[] destinationArray, int destinationIndex, int length)
        {
            AssertThat.IsTrue(ReadPosition + length < Size);
            AssertThat.IsTrue(destinationIndex + length < destinationArray.Length);
            Array.Copy(Buffer, ReadPosition, destinationArray, destinationIndex, length);
            ReadPosition += length;
        }

        public void Write(T[] sourceArray)
        {
            var targetLength = WritePosition + sourceArray.Length;
            if (Size > targetLength)
            {
                Array.Copy(sourceArray, 0, Buffer, WritePosition, sourceArray.Length);
                WritePosition += sourceArray.Length;
            }
            else
            {
                var blockCount = sourceArray.Length / BlockSize;
                blockCount++;
                var blockSize = blockCount * BlockSize;
                var newArray = new T[Size + blockSize];
                Array.Copy(Buffer, ReadPosition, newArray, 0, WritePosition - ReadPosition);
                Array.Copy(sourceArray, 0, newArray, WritePosition - ReadPosition, sourceArray.Length);
                WritePosition = WritePosition - ReadPosition + sourceArray.Length;
                Buffer = newArray;
            }
        }

        public void Write(T[] sourceArray, int sourceIndex, int length)
        {
            var targetLength = WritePosition + length;
            if (Size > targetLength)
            {
                Array.Copy(sourceArray, sourceIndex, Buffer, WritePosition, length);
                WritePosition += length;
            }
            else
            {
                var blockCount = length / BlockSize;
                blockCount++;
                var blockSize = blockCount * BlockSize;
                var newArray = new T[Size + blockSize];
                Array.Copy(Buffer, ReadPosition, newArray, 0, WritePosition - ReadPosition);
                Array.Copy(sourceArray, sourceIndex, newArray, WritePosition - ReadPosition, length);
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
