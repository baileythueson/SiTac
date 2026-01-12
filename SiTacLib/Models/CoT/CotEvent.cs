using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

[XmlRoot(ElementName = "event")]
public class CotEvent
{
    [XmlAttribute] public string Version { get; set; } = "2.0";
    [XmlAttribute] public required string Uid { get; set; }
    [XmlAttribute] public required string Type { get; set; }
    
    [XmlAttribute] public required DateTime Time { get; set; }
    [XmlAttribute] public required DateTime Start { get; set; }
    [XmlAttribute] public required DateTime Stale { get; set; }
    [XmlAttribute] public required string How { get; set; }
    [XmlAttribute] public string? Opex { get; set; }
    [XmlAttribute] public string? Qos { get; set; }
    [XmlAttribute] public string? Access { get; set; }
    
    [XmlElement(ElementName = "point")]
    public required CotPoint Point { get; set;}
    
    [XmlElement(ElementName = "detail")]
    public CotDetail? Detail { get; set;}
}