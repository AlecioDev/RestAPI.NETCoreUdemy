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
            // VALIDAÇÃO SE OS NUMEROS DE ENTRADA SÃO NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok (sum.ToString());
            }
            // SE NÃO FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtração(string firstNumber, string secondNumber)
        {
            // VALIDAÇÃO SE OS NUMEROS DE ENTRADA SÃO NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            // SE NÃO FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicação(string firstNumber, string secondNumber)
        {
            // VALIDAÇÃO SE OS NUMEROS DE ENTRADA SÃO NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            // SE NÃO FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Divisão(string firstNumber, string secondNumber)
        {
            // VALIDAÇÃO SE OS NUMEROS DE ENTRADA SÃO NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            // SE NÃO FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Média(string firstNumber, string secondNumber)
        {
            // VALIDAÇÃO SE OS NUMEROS DE ENTRADA SÃO NUMERICOS
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(sum.ToString());
            }
            // SE NÃO FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult RaizQuadrada(string firstNumber)
        {
            // VALIDAÇÃO SE OS NUMEROS DE ENTRADA SÃO NUMERICOS
            if (IsNumeric(firstNumber) && firstNumber != "0")
            {
                var raiz = double.Parse(firstNumber);
                var sum = Math.Sqrt(raiz);
                return Ok(sum.ToString());
            }
            // SE NÃO FOREM NUMERICOS RETORNA FALHA NA ENTRADA DE VALORES COMO BAD REQUEST
            return BadRequest("Invalid Input");
        }

        bool IsNumeric(string strNumber) // METODO DE VERIFICAÇÃO SE OS VALORES SÃO NUMERICOS
        {
            double number;
            bool isNumber = double.TryParse
                (strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        private decimal ConvertToDecimal(string strNumber) // METODO DE CONVERSÃO DE STRING PARA DECIMAL
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