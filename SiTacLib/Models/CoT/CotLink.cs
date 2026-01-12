using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotLink
{
    [XmlAttribute] public required string uid { get; set; }
    [XmlAttribute] public required string type { get; set; }
    [XmlAttribute] public required string relation { get; set; }
    
    [XmlAttribute] public string? mime { get; set; }
    [XmlAttribute] public DateTime? production_time { get; set; }
    [XmlAttribute] public string? parent_callsign { get; set; }
}