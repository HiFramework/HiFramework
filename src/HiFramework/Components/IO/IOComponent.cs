/****************************************************************************
 * Description: 
 * 
 * Document: https://github.com/hiramtan/HiFramework
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;
using System.IO;

namespace HiFramework
{
    internal class IOComponent : ComponentBase, IIO
    {
        /// <summary>
        /// 递归复制文件夹
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        public void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (true)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath);
                }
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] ReadFile(string path)
        {
            AssertThat.IsTrue(File.Exists(path));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                fs.Close();
                return bytes;
            }
        }

        /// <summary>
        /// 异步读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="onFinish"></param>
        public void ReadFileAsync(string path, Action<byte[]> onFinish)
        {
            AssertThat.IsTrue(File.Exists(path));
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.BeginRead(bytes, 0, (int)fs.Length, temp =>
               {
                   var tempFileStream = (FileStream)temp.AsyncState;
                   tempFileStream.EndRead(temp);
                   tempFileStream.Close();
                   onFinish(bytes);
               }, fs);
            }
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        public void WriteFile(string path, byte[] bytes)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(0, SeekOrigin.End);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
        }

        /// <summary>
        /// 异步写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        /// <param name="onFinish"></param>
        public void WriteFileAsync(string path, byte[] bytes, System.Action onFinish)
        {
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Seek(0, SeekOrigin.End);
                fs.BeginWrite(bytes, 0, bytes.Length, temp =>
                {
                    var tempFileStream = (FileStream)temp.AsyncState;
                    tempFileStream.EndWrite(temp);
                    tempFileStream.Close();
                    onFinish();
                }, fs);
            }
        }

        public override void OnCreated()
        {

        }

        public override void OnDestroy()
        {

        }
    }
}