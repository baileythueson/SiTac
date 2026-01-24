using System.Text;
using System.Xml.Serialization;
using SiTacLib.Models.CoT;

namespace SiTacTest;

internal class Utils
{
    /// <summary>
    /// Serializes an object of type <typeparamref name="T"/> to its XML representation as a string.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize. Must be a reference type.</typeparam>
    /// <param name="original">The original object to serialize.</param>
    /// <returns>Returns the serialized XML string representation of the object.</returns>
    internal static string Serialize<T>(T original) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        serializer.Serialize(writer, original);
        return writer.ToString();
    }

    /// <summary>
    /// Deserializes an XML string into an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize. Must be a reference type.</typeparam>
    /// <param name="xml">The XML string representation of the object to deserialize.</param>
    /// <returns>Returns the deserialized object of type <typeparamref name="T"/>. Returns null if deserialization fails.</returns>
    internal static T? Deserialize<T>(string xml) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        return serializer.Deserialize(new StringReader(xml)) as T;
    }
    
    /// <summary>
    /// Serializes an object of type <typeparamref name="T"/> to XML format and then deserializes it back to an object.
    /// </summary>
    /// <typeparam name="T">The type of the object to be serialized and deserialized.</typeparam>
    /// <param name="original">The original object to serialize and deserialize.</param>
    /// <returns>Returns the deserialized object of type <typeparamref name="T"/>. Returns null if deserialization fails.</returns>
    internal static T? SerializeDeserialize<T>(T original) where T : class
    {
        var xml = Serialize(original);
        return Deserialize<T>(xml);
    }

    /// <summary>
    /// Generates a test Cursor on Target (CoT) event used for unit testing purposes.
    /// The generated event contains pre-defined attributes and nested details, including metadata
    /// such as contact information, track details, and status. It also includes hierarchical relationships
    /// and additional properties like device and platform information.
    /// </summary>
    /// <returns>Returns a fully initialized <see cref="CotEvent"/> instance with representative values configured for testing.</returns>
    internal static CotEvent GenerateTestCoTEvent()
    {
        var cotEvent = new CotEvent
        {
            Uid = "Drone-Alpha-01",
            Type = "a-f-A-M-F-Q",
            Time = DateTime.Now,
            Stale = DateTime.Now.AddYears(2),
            Start = default,
            How = "m-g",
            Opex = "TestOp",
            Qos = "1-r-c",
            Access = "Unclassified",

            Point = new CotPoint()
            {
                Lat = 41.5,
                Lon = -111.8,
                Hae = 1500,
                Ce = 10,
                Le = 5
            },
            
            Detail = new CotDetail()
            {
                Contact = new CotContact { Callsign = "Viper-01", },
                Track = new CotTrack { Course = 180, Speed = 45.5 },
                Remarks = "Visual confirmation required",
                
                Group = new CotGroup { Name = "Alpha-Team", Role = "Scout" },
                Status = new CotStatus { Battery = 90, Ready = true },
                TakVersion = new TakVersion
                {
                    Device = "DroneController",
                    Os = "Linux",
                    Platform = "SiTac",
                    Version = "1.0.0"
                },
                
                DroneStats = new DroneStats
                {
                    Battery = 85.0,
                    Fuel = 100.0,
                    WeaponStatus = "Safe"
                },
                
                FlowTags = new CotFlowTags { Android = DateTime.UtcNow }
            }
        };
        
        cotEvent.Detail.Links.Add(new CotLink
        {
            uid = "parent-uid-123",
            type = "a-f-G",
            relation = "p-p",
            mime = "text/xml"
        });
        
        return cotEvent;
    }
}