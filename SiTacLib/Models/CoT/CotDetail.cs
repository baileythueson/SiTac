using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

public class CotDetail
{
    // --- Core CoT Elements ---
    
    [XmlElement(ElementName = "contact")]
    public CotContact? Contact { get; set; }
    
    [XmlElement(ElementName = "track")]
    public CotTrack? Track { get; set; }
    
    [XmlElement(ElementName = "link")]
    public List<CotLink> Links { get; set; } = new();

    [XmlElement(ElementName = "remarks")]
    public string? Remarks { get; set; }

    [XmlElement(ElementName = "status")]
    public CotStatus? Status { get; set; }

    [XmlElement(ElementName = "__group")]
    public CotGroup? Group { get; set; }

    // --- Common TAK Extensions ---

    [XmlElement(ElementName = "takv")]
    public TakVersion? TakVersion { get; set; }

    [XmlElement(ElementName = "flow-tags")]
    public CotFlowTags? FlowTags { get; set; }
    
    // --- Custom Extensions ---

    [XmlElement(ElementName = "drone_stats", Namespace = "SiTac")]
    public DroneStats? DroneStats { get; set; }
    
    // Catch-all for unknown extensions to prevent data loss during serialization cycles
    [XmlAnyElement]
    public XmlElement[]? OtherElements { get; set; } 
    
    
    public void Validate()
    {
        if (DroneStats is not null)
        {
            if (DroneStats.Battery < 0 || DroneStats.Battery > 100)
                throw new CotValidationException(nameof(DroneStats.Battery),
                    DroneStats.Battery.ToString(CultureInfo.InvariantCulture), "Battery must be between 0 and 100");
        }

        if (Status is not null)
        {
            if (Status.Battery < 0 || Status.Battery > 100)
                throw new CotValidationException(nameof(Status.Battery),
                    Status.Battery.ToString(CultureInfo.InvariantCulture), "Battery must be between 0 and 100");
        }
    }
}