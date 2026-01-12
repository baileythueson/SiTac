using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotGroup
{
    [XmlAttribute] public required string name { get; set; }
    [XmlAttribute] public required string role { get; set; }
}