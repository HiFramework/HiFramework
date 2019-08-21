/****************************************************************************
 * Description:Circle buffer is fixed size and reuse
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public interface ICircleBuffer<T> : IDisposable
    {
        /// <summary>
        /// Array of buffer
        /// </summary>
        T[] Buffer { get; }

        /// <summary>
        /// Buffer's capacity, total size of this buff
        /// </summary>
        int Capacity { get; }

        int ReadPosition { get; }
        int WritePosition { get; }

        /// <summary>
        /// If large than capacity, will move to head
        /// </summary>
        /// <param name="length"></param>
        void MoveReadPostion(int length);

        /// <summary>
        /// If large than capacity, will move to head
        /// </summary>
        /// <param name="length"></param>
        void MoveWritePosition(int length);
        void MoveReadPositionTo(int index);
        void MoveWritePostionTo(int index);

        /// <summary>
        /// If large than capacity, will read head
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        T[] Read(int length);

        /// <summary>
        /// If large than capacity, will read head
        /// </summary>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        void Read(T[] destinationArray, int destinationIndex, int length);

        /// <summary>
        /// If large than capacity, will wirte head
        /// </summary>
        /// <param name="sourceArray"></param>
        void Write(T[] sourceArray);

        /// <summary>
        /// If large than capacity, will wirte head
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="length"></param>
        void Write(T[] sourceArray, int sourceIndex, int length);
    }
}
