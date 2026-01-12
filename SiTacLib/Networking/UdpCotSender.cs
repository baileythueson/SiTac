using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using SiTacLib.Models.CoT;

namespace SiTacLib.Networking;

/// <summary>
/// UdpCotSender provides functionality to send Cursor on Target (CoT) events
/// over UDP. It implements the ICotSender interface and uses XML serialization
/// to generate the CoT event payload in XML format.
/// </summary>
/// <remarks>
/// This class is designed for transmitting CoT messages to specified destinations using the UDP protocol.
/// It handles serialization of CoTEvent objects and ensures proper resource cleanup through the IDisposable pattern.
/// The class also supports logging of send operations and errors using an ILogger instance, enabling
/// the ability to trace or debug the sending process.
/// </remarks>
/// <example>
/// To use this class, instantiate it with an ILogger<UdpCotSender> instance, and call SendAsync with appropriate parameters:
/// - A populated CoTEvent object.
/// - The target IP address.
/// - The target port number.
/// </example>
/// <threadSafety>
/// This class is not thread-safe. Multiple threads accessing the same instance
/// of UdpCotSender should synchronize access to ensure proper operation.
/// </threadSafety>
/// <disposal>
/// Proper disposal of this class is critical once it is no longer needed. Call
/// the Dispose method to release any resources held by this class, including
/// the UDP client.
/// </disposal>
public sealed class UdpCotSender : ICotSender, IDisposable
{
    private UdpClient? _udpClient;
    private readonly ILogger<UdpCotSender> _logger;
    private readonly XmlSerializer _serializer;
    
    private bool _isDisposed = false;
    
    public UdpCotSender(ILogger<UdpCotSender> logger)
    {
        _logger = logger;
        _udpClient = new UdpClient();
        _udpClient.EnableBroadcast = true;
        _serializer = new XmlSerializer(typeof(CotEvent));
    }
    
    public async Task SendAsync(CotEvent cotEvent, string targetIp, int port)
    {
        if (_udpClient is null) return;

        try
        {
            using var stringWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false });

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            _serializer.Serialize(xmlWriter, cotEvent, ns);
            string xmlPayload = stringWriter.ToString();
            
            byte[] data = Encoding.UTF8.GetBytes(xmlPayload);
            
            int bytesSent = await _udpClient.SendAsync(data, data.Length, targetIp, port);
            
            _logger.LogTrace("Sent CoT Event {Uid} ({Bytes} bytes) to {Ip}:{Port}", cotEvent.uid, bytesSent, targetIp, port);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to send CoT Event {Uid}", cotEvent.uid);
        }
    }
    
    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        _udpClient?.Dispose();
        _udpClient = null;
    }
}