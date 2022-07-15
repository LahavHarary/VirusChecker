using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirusChecker.Models;

namespace VirusChecker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirusCheckerController : ControllerBase
    {

        private readonly VirusCheckerConfig _virusCheckerConfig;
        private readonly IConnector _virusConnector;

        public VirusCheckerController(VirusCheckerConfig virusCheckerConfig, IConnector virusConnector)
        {
            _virusCheckerConfig = virusCheckerConfig;
            _virusConnector = virusConnector;
        }

        // POST: api/VirusChecker
        [HttpPost]
        public async Task<VirusReportPresentor> Post([FromBody] VirusCheckerInput virusCheckerInput)
        {
            string filePath = _virusCheckerConfig.FileStorageDirectoryPath +"\\" +virusCheckerInput.FileName;
            await System.IO.File.WriteAllTextAsync(filePath, virusCheckerInput.FileContent);
            File virusCheckerFile = new File(filePath);
            VirusReport res = await _virusConnector.Submit(virusCheckerFile);

            return new VirusReportPresentor()
            {
                FileExtension = res.FileExtension,
                IsVirus = res.IsVirus,
                ResponseTime = DateTime.Now
            };
        }
    }


}


