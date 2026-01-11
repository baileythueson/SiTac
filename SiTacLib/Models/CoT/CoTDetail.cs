using System.Xml;
using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CoTDetail
{
    [XmlElement(ElementName = "contact")]
    public CoTContact contact { get; set; }
    
    [XmlElement(ElementName = "track")]
    public CoTTrack track { get; set; }
    
    [XmlElement(ElementName = "drone_stats", Namespace = "SiTac")]
    public DroneStats drone_stats { get; set; }
    
    [XmlAnyElement]
    public XmlElement[] OtherElements { get; set; } // avoid crashes
}