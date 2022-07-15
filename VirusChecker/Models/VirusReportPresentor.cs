using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirusChecker.Models
{
    public class VirusReportPresentor
    {
        public string FileExtension { get; set; }
        public DateTime ResponseTime { get; set; }
        public bool IsVirus { get; set; }
    }
}
