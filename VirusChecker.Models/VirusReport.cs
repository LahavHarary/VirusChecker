using System;
using System.Collections.Generic;
using System.Text;

namespace VirusChecker.Models
{
    public class VirusReport
    {
        public string FileExtension { get; set; }
        public bool IsVirus{ get; set; }
    }
}
