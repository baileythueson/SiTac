using System.Globalization;
using System.Xml.Serialization;

namespace SiTacLib.Models.CoT;

/// <summary>
/// Represents a geographic point as defined in the Cursor on Target (CoT) format.
/// The class includes latitude, longitude, and additional attributes for height,
/// circular error, and linear error.
/// </summary>
public class CotPoint
{
    [XmlAttribute] public double Lat { get; set; }
    [XmlAttribute] public double Lon { get; set; }
    [XmlAttribute] public double Hae { get; set; }
    [XmlAttribute] public double Ce { get; set; }
    [XmlAttribute] public double Le { get; set; }

    /// <summary>
    /// Validates the properties of the CotPoint instance to ensure that they conform to
    /// specific constraints. Throws a CotValidationException if any property is invalid.
    /// </summary>
    /// <exception cref="CotValidationException">
    /// Thrown when one or more property values of the instance are invalid:
    /// lat must be between -90 and 90 degrees.
    /// lon must be between -180 and 180 degrees.
    /// ce must be positive.
    /// le must be positive.
    /// </exception>
    public void Validate()
    {
        if (Lat < -90 || Lat > 90)
            throw new CotValidationException(nameof(Lat), Lat.ToString(CultureInfo.InvariantCulture),
                "Latitude must be between -90 and 90 degrees.");
        if (Lon < -180 || Lon > 180)
            throw new CotValidationException(nameof(Lon), Lon.ToString(CultureInfo.InvariantCulture),
                "Longitude must be between -180 and 180 degrees.");

        if (Ce < 0)
            throw new CotValidationException(nameof(Ce), Ce.ToString(CultureInfo.InvariantCulture),
                "Ce must be positive.");
        
        if (Le < 0)
            throw new CotValidationException(nameof(Le), Le.ToString(CultureInfo.InvariantCulture),
                "Le must be positive.");
    }
}
