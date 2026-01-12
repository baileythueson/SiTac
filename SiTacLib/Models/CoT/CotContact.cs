using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotContact
{
    [XmlAttribute] public required string Callsign { get; set; }
}