using Assessment.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessementController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IScoreService _scoreService;
        public AssessementController(ICountryService countryService, IScoreService scoreService) 
        {
            _countryService = countryService;
            _scoreService = scoreService;
            
        }

        [HttpGet("Country")]
        public async Task<IActionResult> GetCountry(string phone)
        {
            phone = Regex.Replace(phone, @"[^0-9]", "");

            var result = await _countryService.GetCountryByPhoneNumberAsync(phone);

            if(result == null)
            {
                return BadRequest("invalid country code");
            }

            return Ok(result);
        }
        [HttpPost("Score")]
        public IActionResult GetScore([FromBody] List<int> numbers)
        {


            var result =  _scoreService.CalculateScore(numbers);

            return Ok(result);
        }



    }
}
