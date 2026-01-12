using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotTrack
{
    [XmlAttribute] public double course { get; set; }
    [XmlAttribute] public double speed { get; set; }
}