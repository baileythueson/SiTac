using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CoTContact
{
    [XmlAttribute] public string callsign { get; set; }
}