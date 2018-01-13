using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class FileThread
    {
        public FileThread()
        {

        }

        public byte[] GetFileData(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, buffur.Length);
                fs.Close();

                return buffur;
            }
        }

        public string GetFileString(string filePath)
        {
            return Encoding.UTF8.GetString(GetFileData(filePath));
        }
    }
}
