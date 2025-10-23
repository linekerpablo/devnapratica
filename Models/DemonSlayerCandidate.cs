namespace DevNaPraticaApi.Models
{
    public class DemonSlayerCandidate
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int PhysicalStrength { get; set; } // 1-10
        public int MentalResilience { get; set; } // 1-10
        public int SwordSkill { get; set; } // 1-10
        public bool HasFamilyTrauma { get; set; }
        public string BreathingStyle { get; set; } = string.Empty;
    }

    public class EvaluationResult
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;
        public List<string> Recommendations { get; set; } = new List<string>();
    }
}