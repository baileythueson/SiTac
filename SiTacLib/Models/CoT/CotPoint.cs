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
    [XmlAttribute] public double lat { get; set; }
    [XmlAttribute] public double lon { get; set; }
    [XmlAttribute] public double hae { get; set; }
    [XmlAttribute] public double ce { get; set; }
    [XmlAttribute] public double le { get; set; }

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
        if (lat < -90 || lat > 90)
            throw new CotValidationException(nameof(lat), lat.ToString(CultureInfo.InvariantCulture),
                "Latitude must be between -90 and 90 degrees.");
        if (lon < -180 || lon > 180)
            throw new CotValidationException(nameof(lon), lon.ToString(CultureInfo.InvariantCulture),
                "Longitude must be between -180 and 180 degrees.");

        if (ce < 0)
            throw new CotValidationException(nameof(ce), ce.ToString(CultureInfo.InvariantCulture),
                "Ce must be positive.");
        
        if (le < 0)
            throw new CotValidationException(nameof(le), le.ToString(CultureInfo.InvariantCulture),
                "Le must be positive.");
    }
}
