namespace SiTacLib.Models.CoT;

public static class CotTypeHelper
{
    private const string AtomPrefix = "a";

    /// <summary>
    /// Generates a CoT (Cursor-on-Target) type string based on the supplied affiliation, dimension, and optional subtype.
    /// </summary>
    /// <param name="affiliation">The CoT affiliation used to determine the second character of the type string.</param>
    /// <param name="dimension">The CoT dimension used to determine the third character of the type string.</param>
    /// <param name="subType">An optional subtype appended to the end of the type string if provided.</param>
    /// <returns>A string representing the CoT type, formatted as "a-[affiliation]-[dimension]-[subtype]".</returns>
    public static string Generate(CotAffiliation affiliation, CotDimension dimension, string? subType = null)
    {
        char affChar = GetAffiliationChar(affiliation);
        char dimChar = GetDimensionChar(dimension);
        
        string type = $"{AtomPrefix}-{affChar}-{dimChar}";
        if (!string.IsNullOrEmpty(subType)) type += $"-{subType}";
        
        return type;
    }
    
    public static char GetAffiliationChar(CotAffiliation affiliation) => affiliation switch
    {
        CotAffiliation.Pending => 'p',
        CotAffiliation.Unknown => 'u',
        CotAffiliation.AssumedFriend => 'a',
        CotAffiliation.Friend => 'f',
        CotAffiliation.Neutral => 'n',
        CotAffiliation.Suspect => 's',
        CotAffiliation.Hostile => 'h',
        CotAffiliation.Joker => 'j',
        CotAffiliation.Faker => 'k',
        CotAffiliation.None => 'o',
        _ => 'u' // Default to Unknown
    };

    public static char GetDimensionChar(CotDimension dimension) => dimension switch
    {
        CotDimension.Space => 'P',
        CotDimension.Air => 'A',
        CotDimension.Ground => 'G',
        CotDimension.SeaSurface => 'S',
        CotDimension.Subsurface => 'U',
        CotDimension.Other => 'X',
        _ => 'X' // Default to Other
    };
}