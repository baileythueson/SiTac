using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

[XmlRoot(ElementName = "event")]
public class CotEvent
{
    [XmlAttribute] public string Version { get; set; } = "2.0";
    [XmlAttribute] public required string Uid { get; set; }
    [XmlAttribute] public required string Type { get; set; }
    
    [XmlAttribute] public required DateTime Time { get; set; }
    [XmlAttribute] public required DateTime Start { get; set; }
    [XmlAttribute] public required DateTime Stale { get; set; }
    [XmlAttribute] public required string How { get; set; }
    [XmlAttribute] public string? Opex { get; set; }
    [XmlAttribute] public string? Qos { get; set; }
    [XmlAttribute] public string? Access { get; set; }
    
    [XmlElement(ElementName = "point")]
    public required CotPoint Point { get; set;}
    
    [XmlElement(ElementName = "detail")]
    public CotDetail? Detail { get; set;}
    
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Uid)) throw new CotValidationException(nameof(Uid), Uid, "UID is required");
        if (string.IsNullOrWhiteSpace(Type)) throw new CotValidationException(nameof(Type), Type, "Type is required");

        if (Stale <= Start) throw new CotValidationException(nameof(Stale), "Stale must be greater than Start", nameof(Stale));
        
        if (Time <= Start) throw new CotValidationException(nameof(Time), "Time must be greater than Start", nameof(Time));
        
        if (Time >= Stale) throw new CotValidationException(nameof(Time), "Time must be less than Stale", nameof(Time));
        
        if (string.IsNullOrWhiteSpace(How)) throw new CotValidationException(nameof(How), How, "How is required");
        
        if (Point is null) throw new CotValidationException(nameof(Point), "Point is required");
        
        Point.Validate();
        
        Detail?.Validate();
    }
    
    public static CotEvent FromXml(string xml) => 
        (CotEvent) new XmlSerializer(typeof(CotEvent)).Deserialize(new StringReader(xml))! 
        ?? throw new CotValidationException("Failed to deserialize XML") ;
}