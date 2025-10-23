namespace DevNaPraticaApi.Models
{
    public interface IEvaluationStrategy
    {
        bool CanHandle(DemonSlayerCandidate candidate);
        EvaluationResult Evaluate(DemonSlayerCandidate candidate);
        int Priority { get; }
    }
}