using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VirusChecker.Models
{
    public class File : IFile
    {
        #region Properties
        public Stream FileStream { get; }
        #endregion

        #region Ctor

        public File(string fPath)
        {
            FileStream = System.IO.File.OpenRead(fPath);
        } 

        #endregion
    }
}
