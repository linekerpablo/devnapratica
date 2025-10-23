namespace DevNaPraticaApi.Models
{
    public class TooYoungStrategy : IEvaluationStrategy
    {
        public int Priority => 1; // Maior prioridade - deve ser verificado primeiro

        public bool CanHandle(DemonSlayerCandidate candidate)
        {
            return candidate.Age < 12;
        }

        public EvaluationResult Evaluate(DemonSlayerCandidate candidate)
        {
            return new EvaluationResult
            {
                Status = "REJEITADO",
                Message = "Muito jovem para enfrentar demônios! Volte quando crescer um pouco mais.",
                Rank = "N/A",
                Recommendations = new List<string>
                {
                    "Treine técnicas básicas de respiração",
                    "Desenvolva força física",
                    "Estude sobre demônios"
                }
            };
        }
    }

    public class InsufficientAttributesStrategy : IEvaluationStrategy
    {
        public int Priority => 2;

        public bool CanHandle(DemonSlayerCandidate candidate)
        {
            return candidate.PhysicalStrength < 5 || candidate.MentalResilience < 5;
        }

        public EvaluationResult Evaluate(DemonSlayerCandidate candidate)
        {
            return new EvaluationResult
            {
                Status = "REJEITADO",
                Message = "Força física ou resistência mental insuficiente. Os demônios não terão piedade!",
                Rank = "N/A",
                Recommendations = new List<string>
                {
                    "Treine intensivamente por 6 meses",
                    "Pratique meditação",
                    "Fortaleça o corpo e a mente"
                }
            };
        }
    }

    public class PoorSwordSkillStrategy : IEvaluationStrategy
    {
        public int Priority => 3;

        public bool CanHandle(DemonSlayerCandidate candidate)
        {
            return candidate.SwordSkill < 3;
        }

        public EvaluationResult Evaluate(DemonSlayerCandidate candidate)
        {
            return new EvaluationResult
            {
                Status = "REJEITADO",
                Message = "Habilidades com espada muito básicas. Você seria derrotado no primeiro encontro!",
                Rank = "N/A",
                Recommendations = new List<string>
                {
                    "Aprenda técnicas básicas de esgrima",
                    "Pratique cortes e estocadas",
                    "Domine pelo menos uma forma de respiração"
                }
            };
        }
    }

    public class EliteCandidateStrategy : IEvaluationStrategy
    {
        public int Priority => 4;

        public bool CanHandle(DemonSlayerCandidate candidate)
        {
            return candidate.PhysicalStrength >= 8 && 
                   candidate.MentalResilience >= 8 && 
                   candidate.SwordSkill >= 7 && 
                   candidate.HasFamilyTrauma;
        }

        public EvaluationResult Evaluate(DemonSlayerCandidate candidate)
        {
            return new EvaluationResult
            {
                Status = "APROVADO - ELITE",
                Message = $"Bem-vindo ao Demon Slayer Corps, {candidate.Name}! Você tem potencial para ser um Hashira!",
                Rank = "KINOE",
                Recommendations = new List<string>
                {
                    "Treinamento avançado com um Hashira",
                    "Desenvolva sua própria técnica de respiração",
                    "Lidere missões importantes"
                }
            };
        }
    }

    public class ApprovedCandidateStrategy : IEvaluationStrategy
    {
        public int Priority => 5;

        public bool CanHandle(DemonSlayerCandidate candidate)
        {
            return candidate.PhysicalStrength >= 6 && 
                   candidate.MentalResilience >= 6 && 
                   candidate.SwordSkill >= 5;
        }

        public EvaluationResult Evaluate(DemonSlayerCandidate candidate)
        {
            return new EvaluationResult
            {
                Status = "APROVADO",
                Message = $"Parabéns {candidate.Name}! Você foi aceito no Demon Slayer Corps!",
                Rank = "MIZUNOTO",
                Recommendations = new List<string>
                {
                    "Comece com missões de baixo risco",
                    "Aprimore suas técnicas de respiração",
                    "Trabalhe em equipe com outros slayers"
                }
            };
        }
    }

    public class DefaultEvaluationStrategy : IEvaluationStrategy
    {
        public int Priority => 999; // Menor prioridade - estratégia padrão

        public bool CanHandle(DemonSlayerCandidate candidate)
        {
            return true; // Sempre pode lidar com qualquer candidato (fallback)
        }

        public EvaluationResult Evaluate(DemonSlayerCandidate candidate)
        {
            return new EvaluationResult
            {
                Status = "EM ANÁLISE",
                Message = "Seu caso precisa de uma avaliação mais detalhada pelos Hashiras.",
                Rank = "PENDENTE",
                Recommendations = new List<string>
                {
                    "Aguarde contato dos instrutores",
                    "Continue treinando",
                    "Mantenha-se preparado"
                }
            };
        }
    }
}