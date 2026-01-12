using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class TakVersion
{
    [XmlAttribute] public required string Device { get; set; }
    [XmlAttribute] public required string Platform { get; set; }
    [XmlAttribute] public required string Os { get; set; }
    [XmlAttribute] public required string Version { get; set; }
}