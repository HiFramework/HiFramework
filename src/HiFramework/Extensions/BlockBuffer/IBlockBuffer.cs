/****************************************************************************
 * Description:BlockBuffer can dynamic extend
 * Will automatical change array size
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public interface IBlockBuffer<T> : IDisposable
    {
        /// <summary>
        /// Array of buffer
        /// </summary>
        T[] Buffer { get; }

        /// <summary>
        /// Buffer's size
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Every extend block size
        /// </summary>
        int BlockSize { get; set; }

        int ReadPosition { get; }
        int WritePosition { get; }

        void MoveReadPostion(int length);
        void MoveWritePosition(int length);
        void MoveReadPositionTo(int index);
        void MoveWritePostionTo(int index);

        /// <summary>
        /// Read data and alse move readpostion
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        T[] Read(int length);

        /// <summary>
        /// Read data and also move readposition
        /// </summary>
        /// <param name="destinationArray"></param>
        /// <param name="destinationIndex"></param>
        /// <param name="length"></param>
        void Read(T[] destinationArray, int destinationIndex, int length);

        /// <summary>
        /// Write data and also move writeposition
        /// </summary>
        /// <param name="sourceArray"></param>
        void Write(T[] sourceArray);

        /// <summary>
        /// Write data and also move writeposition
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="length"></param>
        void Write(T[] sourceArray, int sourceIndex, int length);

        /// <summary>
        /// Reset readposition and writepostion
        /// </summary>
        void ResetIndex();
    }
}