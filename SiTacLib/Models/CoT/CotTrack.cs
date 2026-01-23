using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotTrack
{
    [XmlAttribute] public double Course { get; set; }
    [XmlAttribute] public double Speed { get; set; }
}