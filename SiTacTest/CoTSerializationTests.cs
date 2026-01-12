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
            uid = "Drone-Alpha-01",
            type = "a-f-A-M-F-Q",
            time = DateTime.Now,
            stale = DateTime.Now.AddYears(2),
            start = default,
            Point = new CotPoint()
            {
                lat = 41.5,
                lon = -111.8,
                hae = 1500,
            },
            how = "m-g"
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
        xml.Should().Contain("uid=\"Drone-Alpha-01\"");
        xml.Should().Contain("lat=\"41.5\"");
        xml.Should().Contain("lon=\"-111.8\"");
        xml.Should().Contain("hae=\"1500\"");
    }
}