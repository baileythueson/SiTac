using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public sealed class CotFlowTags
{
    [XmlAttribute] public DateTime? Android { get; set; }
}