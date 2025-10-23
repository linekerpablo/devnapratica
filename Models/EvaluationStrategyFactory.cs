namespace DevNaPraticaApi.Models
{
    public class EvaluationStrategyFactory
    {
        private readonly List<IEvaluationStrategy> _strategies;

        public EvaluationStrategyFactory()
        {
            _strategies = new List<IEvaluationStrategy>
            {
                new TooYoungStrategy(),
                new InsufficientAttributesStrategy(),
                new PoorSwordSkillStrategy(),
                new EliteCandidateStrategy(),
                new ApprovedCandidateStrategy(),
                new DefaultEvaluationStrategy()
            };

            // Ordena as estratégias por prioridade (menor número = maior prioridade)
            _strategies = _strategies.OrderBy(s => s.Priority).ToList();
        }

        public IEvaluationStrategy GetStrategy(DemonSlayerCandidate candidate)
        {
            // Retorna a primeira estratégia que pode lidar com o candidato
            // Como a lista está ordenada por prioridade, isso garante que
            // a estratégia mais específica/prioritária seja selecionada
            return _strategies.First(strategy => strategy.CanHandle(candidate));
        }

        public EvaluationResult EvaluateCandidate(DemonSlayerCandidate candidate)
        {
            var strategy = GetStrategy(candidate);
            return strategy.Evaluate(candidate);
        }
    }
}