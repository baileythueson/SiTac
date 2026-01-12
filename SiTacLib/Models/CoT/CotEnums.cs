namespace SiTacLib.Models.CoT;

/// <summary>
/// Standard CoT Affiliation (Identity).
/// Maps to the second character of the Type string (e.g., a-f-G).
/// </summary>
public enum CotAffiliation
{
    Pending,        // p
    Unknown,        // u
    AssumedFriend,  // a
    Friend,         // f
    Neutral,        // n
    Suspect,        // s
    Hostile,        // h
    Joker,          // j
    Faker,          // k
    None            // o
}

/// <summary>
/// Standard CoT Battle Dimension.
/// Maps to the third character of the Type string (e.g., a-f-G).
/// </summary>
public enum CotDimension
{
    Space,          // P
    Air,            // A
    Ground,         // G
    SeaSurface,     // S
    Subsurface,     // U
    Other           // X
}