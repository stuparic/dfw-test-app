using System;
using DfwRest.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DfwRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        private readonly ILogger<WordController> _logger;
        private readonly IWordService _wordService;

        public WordController(ILogger<WordController> logger, IWordService wordService)
        {
            _logger = logger;
            _wordService = wordService;
        }

        [HttpGet]
        [Route("GetFromFile")]
        public TextDto GetFromFile()
        {
            _logger.Log(LogLevel.Information, "get words from file" );

            return DtoDomainMapper.ToDto(_wordService.GetWords(StorageOption.File));
        }

        [HttpGet]
        [Route("GetFromDb")]
        public TextDto GetFromDb()
        {
            _logger.Log(LogLevel.Information, "get words from DB");
            var res = _wordService.GetWords(StorageOption.Db);

            return DtoDomainMapper.ToDto(res);
        }

        [HttpPost]
        [Route("CalculateNumberOfWords")]
        public TextDto CalculateNumberOfWords(TextDto dto)
        {
            _logger.Log(LogLevel.Information, "calculating number of words");

            var domain = DtoDomainMapper.ToDomain(dto);
            _wordService.CalculateNumberOfWords(domain);

            return DtoDomainMapper.ToDto(domain);
        }
    }
}
