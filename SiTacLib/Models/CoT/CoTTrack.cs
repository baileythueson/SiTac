using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CoTTrack
{
    [XmlAttribute] public double course { get; set; }
    [XmlAttribute] public double speed { get; set; }
}