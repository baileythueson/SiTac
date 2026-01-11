using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

[XmlRoot(ElementName = "event")]
public class CoTEvent
{
    [XmlAttribute] public string version { get; set; } = "2.0";
    [XmlAttribute] public string uid { get; set; }
    [XmlAttribute] public string type { get; set; }
    
    [XmlAttribute] public string time { get; set; }
    [XmlAttribute] public string stale { get; set; }
    
    [XmlElement(ElementName = "point")]
    public CoTPoint TPoint { get; set;}
    
    [XmlElement(ElementName = "detail")]
    public CoTDetail detail { get; set;}
}