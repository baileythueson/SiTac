using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class DroneStats
{
    [XmlAttribute] public double Battery { get; set; }
    [XmlAttribute] public double Fuel { get; set; }
    [XmlAttribute] public string WeaponStatus { get; set; }
}