using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CoTPoint
{
    [XmlAttribute] public string lat { get; set; }
    [XmlAttribute] public string lon { get; set; }
    [XmlAttribute] public string hae { get; set; }
}
