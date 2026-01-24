using System.Xml;
using System.Xml.Serialization;
using FluentAssertions;
using SiTacLib.Common;
using SiTacLib.Models.CoT;

namespace SiTacTest;

public class CoTSerializationTests
{
    [Fact]
    public void Serialize_CoTEvent()
    {
        var testEvent = Utils.GenerateTestCoTEvent();
        var xml = Utils.Serialize(testEvent);
        
        // CotEvent
        xml.Should().NotBeNullOrEmpty();
        xml.Should().Contain("Uid=\"Drone-Alpha-01\"");
        xml.Should().Contain("Type=\"a-f-A-M-F-Q\"");
        xml.Should().Contain("Time=\"");
        xml.Should().Contain("Stale=\"");
        xml.Should().Contain("Start=\"");
        xml.Should().Contain("How=\"m-g\"");
        xml.Should().Contain("Opex=\"TestOp\"");
        xml.Should().Contain("Qos=\"1-r-c\"");
        xml.Should().Contain("Access=\"Unclassified\"");
        
        // CotPoint
        xml.Should().Contain("Lat=\"41.5\"");
        xml.Should().Contain("Lon=\"-111.8\"");
        xml.Should().Contain("Hae=\"1500\"");
        xml.Should().Contain("Ce=\"10\"");
        xml.Should().Contain("Le=\"5\"");
        
        // CotDetail
        xml.Should().Contain("Callsign=\"Viper-01\"");
        xml.Should().Contain("Track=\"Course=180 Speed=45.5\"");
        xml.Should().Contain("Remarks=\"Visual confirmation required\"");
        
        // CotGroup
        xml.Should().Contain("Name=\"Alpha-Team\"");
        xml.Should().Contain("Role=\"Scout\"");
        
        // CotStatus
        xml.Should().Contain("Battery=\"90\"");
        xml.Should().Contain("Ready=\"true\"");
        
        // CotTakVersion
        xml.Should().Contain("Device=\"DroneController\"");
        xml.Should().Contain("Os=\"Linux\"");
        xml.Should().Contain("Platform=\"SiTac\"");
        xml.Should().Contain("Version=\"1.0.0\"");
        
        // DroneStats
        xml.Should().Contain("Battery=\"85\"");
        xml.Should().Contain("Fuel=\"100\"");
        xml.Should().Contain("WeaponStatus=\"Safe\"");
        
        // FlowTags
        xml.Should().Contain("Android=\"");
    }
    
    [Fact]
    public void Serialize_Deserialize_CoTEvent()
    {
        var testEvent = Utils.GenerateTestCoTEvent();
        var cotEvent = Utils.SerializeDeserialize(testEvent);
    }
}