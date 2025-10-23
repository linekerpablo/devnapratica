using Microsoft.AspNetCore.Mvc;
using DevNaPraticaApi.Models;

namespace DevNaPraticaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemonSlayerController : ControllerBase
    {
        private readonly EvaluationStrategyFactory _evaluationFactory;

        public DemonSlayerController()
        {
            _evaluationFactory = new EvaluationStrategyFactory();
        }
        [HttpPost("evaluate-candidate")]
        public ActionResult<EvaluationResult> EvaluateCandidate([FromBody] DemonSlayerCandidate candidate)
        {
            // 🎯 ZERO IFS! Código refatorado usando Strategy Pattern
            // Muito mais limpo, extensível e fácil de manter!
            // Agora para adicionar uma nova regra, basta criar uma nova Strategy
            
            var result = _evaluationFactory.EvaluateCandidate(candidate);
            return Ok(result);
        }

        [HttpGet("breathing-styles")]
        public ActionResult<List<string>> GetBreathingStyles()
        {
            var breathingStyles = new List<string>
            {
                "Respiração da Água",
                "Respiração do Fogo",
                "Respiração do Trovão",
                "Respiração da Pedra",
                "Respiração do Vento",
                "Respiração da Névoa",
                "Respiração da Serpente",
                "Respiração das Flores",
                "Respiração do Inseto",
                "Respiração do Som"
            };

            return Ok(breathingStyles);
        }
    }
}