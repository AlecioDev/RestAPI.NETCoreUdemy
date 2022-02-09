using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RestAPI.NETCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;
        private readonly bool isNumber;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            // VALIDA��O SE OS NUMEROS DE ENTRADA S�O NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok (sum.ToString());
            }
            // SE N�O FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtra��o(string firstNumber, string secondNumber)
        {
            // VALIDA��O SE OS NUMEROS DE ENTRADA S�O NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            // SE N�O FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplica��o(string firstNumber, string secondNumber)
        {
            // VALIDA��O SE OS NUMEROS DE ENTRADA S�O NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            // SE N�O FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Divis�o(string firstNumber, string secondNumber)
        {
            // VALIDA��O SE OS NUMEROS DE ENTRADA S�O NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            // SE N�O FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult M�dia(string firstNumber, string secondNumber)
        {
            // VALIDA��O SE OS NUMEROS DE ENTRADA S�O NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }
            // SE N�O FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult RaizQuadrada(string firstNumber)
        {
            // VALIDA��O SE OS NUMEROS DE ENTRADA S�O NUMERICOS
            if (IsNumeric(firstNumber) && firstNumber != "0")
            {
                var raiz = double.Parse(firstNumber);
                var sum = Math.Sqrt(raiz);
                return Ok(sum.ToString());
            }
            // SE N�O FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        bool IsNumeric(string strNumber) // METODO DE VERIFICA��O SE OS VALORES S�O NUMERICOS
        {
            double number;
            bool isNumber = double.TryParse
                (strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        private decimal ConvertToDecimal(string strNumber) // METODO DE CONVERS�O DE STRING PARA DECIMAL
        { 
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        
    }
}