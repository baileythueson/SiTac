using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotStatus
{
    [XmlAttribute] public int Battery { get; set; }
    [XmlAttribute] public bool Ready { get; set; }
}