using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class DroneStats
{
    [XmlAttribute] public double battery { get; set; }
    [XmlAttribute] public double fuel { get; set; }
    [XmlAttribute] public string weapon_status { get; set; }
}