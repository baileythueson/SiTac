using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotPoint
{
    [XmlAttribute] public double lat { get; set; }
    [XmlAttribute] public double lon { get; set; }
    [XmlAttribute] public double hae { get; set; }
    [XmlAttribute] public double ce { get; set; }
    [XmlAttribute] public double le { get; set; }
}
