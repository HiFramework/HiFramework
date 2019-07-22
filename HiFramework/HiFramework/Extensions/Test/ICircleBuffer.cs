using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework.Extensions.Test
{
    interface ICircleBuffer<T> : IDisposable
    {
        T[] Buffer { get; }
        int Capacity { get; }

        int BlockSize { get; set; }

        int HowManyCanRead { get; }
        int HowManyCanWrite { get; }

        int ReadPosition { get; }
        int WritePosition { get; }

        void MoveReadPosition(int size);
        void MoveWritePosition(int size);

        byte[] Read(int length);
        void Read(byte[] toArray, int index, int length);

        void Write(byte[] bytes);
        void Write(byte[] sourceArray, int index, int length);
    }

    public enum State
    {
        Init,
        ReadAhead,
        WriteAhead,
    }
}
