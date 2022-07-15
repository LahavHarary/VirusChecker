using System.IO;

namespace VirusChecker.Models
{
    public interface IFile
    {
        Stream FileStream{ get; }
    }
}