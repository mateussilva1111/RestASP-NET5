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
    public class CalculatorController : ControllerBase
    {
   
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
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
        public IActionResult SubGet(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = CovertToNumber(firstNumber) - CovertToNumber(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult MultGet(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = CovertToNumber(firstNumber) * CovertToNumber(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("invalid Input!!!");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult DivGet(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = CovertToNumber(firstNumber) / CovertToNumber(secondNumber);
                return Ok(sum.ToString());
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
