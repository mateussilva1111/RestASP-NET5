using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWhithASPNET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
   
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber)) 
            {
                var sum = CovertToNumber(firstNumber) + CovertToNumber(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sub = CovertToNumber(firstNumber) - CovertToNumber(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var mult = CovertToNumber(firstNumber) * CovertToNumber(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var div = CovertToNumber(firstNumber) / CovertToNumber(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var mean = (CovertToNumber(firstNumber) + CovertToNumber(secondNumber))/2;
                return Ok(mean.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)CovertToNumber(firstNumber));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }
        private decimal CovertToNumber(string strNumber)
        {
            decimal decimalvalue;

            if (decimal.TryParse(strNumber, out decimalvalue))
            {
                return decimalvalue;
            }

            return 0;
        }

        
    }
}
