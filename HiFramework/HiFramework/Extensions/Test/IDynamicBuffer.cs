using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework.Extensions.Test
{
    interface IDynamicBuffer<T> : IDisposable
    {
        T[] Buffer { get; }
        int Size { get; }
        int BlockSize { get; set; }

        int ReadPosition { get; }
        int WritePosition { get; }

        int HowManyCanRead { get; }
        int HowManyCanWrite { get; }

        void MoveReadPostion(int length);
        void MoveWritePosition(int length);
        void MoveReadPositionTo(int index);
        void MoveWritePostionTo(int index);

        T[] Read(int length);
        void Read(T[] destinationArray, int destinationIndex, int length);

        void Write(T[] sourceArray);
        void Write(T[] sourceArray, int sourceIndex, int length);
    }
}