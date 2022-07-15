using System;
using VirusTotalNet;
using VirusTotalNet.ResponseCodes;
using VirusTotalNet.Results;

namespace VirusChecker.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            VirusTotal virusTotal = new VirusTotal("140a2997f15baf888800e3967bd507aace1bf4086b9fa0bd291fd6583f60f9c2");

            //Use HTTPS instead of HTTP
            virusTotal.UseTLS = true;

            //Create the EICAR test virus. See http://www.eicar.org/86-0-Intended-use.html
            byte[] eicar = System.Text.Encoding.ASCII.GetBytes(@"X5O!P%@AP[4\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*");

            //Check if the file has been scanned before.
            FileReport report = virusTotal.GetFileReportAsync(eicar).Result;

            Console.WriteLine("Seen before: " + (report.ResponseCode == FileReportResponseCode.Present ? "Yes" : "No"));
        }
    }
}
