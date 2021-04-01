using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetEmpty(string firstNumber, string secondNumber)
        {
            return Ok("type Url sum/fistnumber/secondnumber");
        }


        [HttpGet("sum/{firstNumber}/{secondnumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            bool IsDecimal(string strValue) =>
                decimal.TryParse(strValue,
                                 System.Globalization.NumberStyles.Any,
                                 System.Globalization.NumberFormatInfo.InvariantInfo,
                                 out decimal value);


            if (IsDecimal(firstNumber) && IsDecimal(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input parameters");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal valor;
            if (decimal.TryParse(strNumber, out valor))
            {
                return valor;
            }
            return 0;
        }
    }
}
