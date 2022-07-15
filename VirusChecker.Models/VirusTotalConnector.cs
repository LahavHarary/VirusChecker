using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirusTotalNet;
using VirusTotalNet.Results;

namespace VirusChecker.Models
{
    public class VirusTotalConnector : IConnector
    {
        #region Fields

        private readonly VirusTotal _virusTotal;
        private readonly double _threshPrecentageViruses;

        #endregion

        #region Ctor

        public VirusTotalConnector(string apiKey, double threshPrecentageViruses)
        {
            _virusTotal = new VirusTotal(apiKey);
            _threshPrecentageViruses = threshPrecentageViruses;
            _virusTotal.UseTLS = true;
        } 

        #endregion

        #region Methods

        public async Task<VirusReport> Submit(IFile file)
        {
            //Check if the file has been scanned before.
            FileReport report = await _virusTotal.GetFileReportAsync(file.FileStream);

            return new VirusReport()
            {
                FileExtension = "",
                IsVirus = (double)report.Positives / report.Total > _threshPrecentageViruses ? true : false
            };

        }

        #endregion
    }
}


