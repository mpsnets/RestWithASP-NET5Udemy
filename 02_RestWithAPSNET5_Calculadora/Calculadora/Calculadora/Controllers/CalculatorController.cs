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
        public IActionResult Get()
        {
            return Ok();
        }


        [HttpGet("sum/{firstNumber}/{secondnumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
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

        [HttpGet("subtraction/{firstNumber}/{secondnumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        { 
            if (IsDecimal(firstNumber) && IsDecimal(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input parameters");
        }

        [HttpGet("multiplication/{firstNumber}/{secondnumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsDecimal(firstNumber) && IsDecimal(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input parameters");
        }

        [HttpGet("division/{firstNumber}/{secondnumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsDecimal(firstNumber) && IsDecimal(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input parameters");
        }

        [HttpGet("mean/{firstNumber}/{secondnumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsDecimal(firstNumber) && IsDecimal(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + Convert.ToDecimal(secondNumber)) / 2 ;
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input parameters");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsDecimal(firstNumber))
            {
                var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid input parameters");
        }

        private bool IsDecimal(string strValue)
            => decimal.TryParse(strValue,
                                System.Globalization.NumberStyles.Any,
                                System.Globalization.NumberFormatInfo.InvariantInfo,
                                out decimal value);
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
