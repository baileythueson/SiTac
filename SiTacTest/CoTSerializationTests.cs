using System.Xml;
using System.Xml.Serialization;
using FluentAssertions;
using SiTacLib.Common;
using SiTacLib.Models.CoT;

namespace SiTacTest;

public class CoTSerializationTests
{
    private CotEvent GenerateTestCoTEvent()
    {
        var cotEvent = new CotEvent
        {
            Uid = "Drone-Alpha-01",
            Type = "a-f-A-M-F-Q",
            Time = DateTime.Now,
            Stale = DateTime.Now.AddYears(2),
            Start = default,
            How = "m-g",

            Point = new CotPoint()
            {
                lat = 41.5,
                lon = -111.8,
                hae = 1500,
            },
        };
        
        return cotEvent;
    }
    
    [Fact]
    public void Serialize_CoTEvent_ShouldProduceValidXml()
    {
        var cotEvent = GenerateTestCoTEvent();
        var xmlSerializer = new XmlSerializer(typeof(CotEvent));
        using var textWriter = new StringWriter();
        xmlSerializer.Serialize(textWriter, cotEvent);
        var xml = textWriter.ToString();

        xml.Should().NotBeNullOrEmpty();
        xml.Should().Contain("Uid=\"Drone-Alpha-01\"");
        xml.Should().Contain("Lat=\"41.5\"");
        xml.Should().Contain("Lon=\"-111.8\"");
        xml.Should().Contain("Hae=\"1500\"");
    }
}