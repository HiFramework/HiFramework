/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/
using System;

namespace HiFramework
{
    public interface IIO
    {
        /// <summary>
        /// 递归复制文件夹
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        void DirectoryCopy(string sourceDirName, string destDirName);

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        byte[] ReadFile(string path);

        /// <summary>
        /// 异步读取文件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="path"></param>
        void ReadFileAsync(string path, Action<byte[]> onFinish);

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        void WriteFile(string path, byte[] bytes);

        /// <summary>
        /// 异步写入文件
        /// </summary>
        /// <param name="action"></param>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        void WriteFileAsync(string path, byte[] bytes, System.Action onFinish);
    }
}