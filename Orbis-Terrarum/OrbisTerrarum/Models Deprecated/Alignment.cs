using System.ComponentModel;

namespace OrbisTerrarum.Models
{
    public enum Alignment
    {
        [Description("Lawful Good")]
        LawfulGood,
        [Description("Neutral Good")]
        NeutralGood,
        [Description("Chaotic Good")]
        ChaoticGood,
        [Description("Lawful Neutral")]
        LawfulNeutral,
        [Description("True Neutral")]
        TrueNeutral,
        [Description("Chaotic Neutral")]
        ChaoticNeutral,
        [Description("Lawful Evil")]
        LawfulEvil,
        [Description("Neutral Evil")]
        NeutralEvil,
        [Description("Chaotic Evil")]
        ChaoticEvil,
    }
}
