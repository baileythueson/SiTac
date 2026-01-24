using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotGroup
{
    [XmlAttribute] public required string Name { get; set; }
    [XmlAttribute] public required string Role { get; set; }
}