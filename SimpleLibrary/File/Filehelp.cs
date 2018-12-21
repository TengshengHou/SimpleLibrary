using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibrary.File
{
    public static class Filehelp
    {
        /// <summary>
        /// 读取文件内容到字符串
        /// </summary>
        /// <param name="path">文件链接</param>
        /// <returns>返回字符串（Utf8）</returns>
        private static async Task<string> ReadFile2StrAsync(string path)
        {
            StringBuilder sb = new StringBuilder(100);
            const int FILE_READ_SIZE = 1000;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, FILE_READ_SIZE, true))
            {
                byte[] vs = new byte[0x1000];
                int numRead = 0;
                while ((numRead = await fs.ReadAsync(vs, 0, vs.Length)) != 0)
                {
                    await Task.Delay(100);
                    sb.Append(Encoding.UTF8.GetString(vs, 0, numRead));
                }
            }
            return sb.ToString();
        }
    }
}
