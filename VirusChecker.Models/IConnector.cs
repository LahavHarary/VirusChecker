using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VirusChecker.Models
{
    public interface IConnector
    {
        Task<VirusReport> Sumbit(IFile file);
    }
}
