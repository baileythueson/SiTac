using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotStatus
{
    [XmlAttribute] public int battery { get; set; }
    [XmlAttribute] public bool ready { get; set; }
}