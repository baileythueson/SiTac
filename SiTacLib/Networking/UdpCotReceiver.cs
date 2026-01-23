using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using SiTacLib.Models.CoT;

namespace SiTacLib.Networking;

/// <summary>
/// Represents a sealed implementation of the ICotReceiver interface for receiving Cursor on Target (CoT)
/// events using the UDP protocol. This class provides functionality to listen for and deserialize CoT events
/// received as XML over a specified UDP port, then raises an event when a CoTEvent is received.
/// </summary>
/// <remarks>
/// This class caches an XML serializer for performance during deserialization and is designed to operate
/// asynchronously in its receive loop. It also integrates a logger for capturing operational details and
/// error information. Ensure to call <see cref="Dispose"/> when done to release resources.
/// </remarks>
public sealed class UdpCotReceiver : ICotReceiver, IDisposable
{
    private UdpClient? _udpClient;
    private bool _isRunning;
    private readonly XmlSerializer _serializer;
    
    private readonly ILogger<UdpCotReceiver> _logger;
    
    public event EventHandler<CotEvent>? CotEventReceived;

    private bool _isDisposed = false;

    public UdpCotReceiver(ILogger<UdpCotReceiver> logger)
    {
        _logger = logger;
        // cache for performance
        _serializer = new XmlSerializer(typeof(CotEvent));
    }

    public void Start(int port)
    {
        if (_isRunning) return;

        try
        {
            _udpClient = new UdpClient(port);
            _isRunning = true;

            Task.Run(ReceiveLoopAsync);

            _logger.LogInformation("Started listening for CoT traffic on UDP {Port}", port);        }
        catch (SocketException e)
        {
            _logger.LogCritical(e, "Failed to start listening for CoT traffic on UDP {Port}", port);
            throw;
        }
    }

    public void Stop()
    {
        _logger.LogInformation("Stopping listening for CoT traffic");
        _isRunning = false;
        _udpClient?.Close();
        _udpClient = null;
    }

    private async Task ReceiveLoopAsync()
    {
        while (_isRunning && _udpClient != null)
        {
            try
            {
                var result = await _udpClient.ReceiveAsync();
                ProcessData(result.Buffer, result.RemoteEndPoint);
            }
            catch (ObjectDisposedException)
            {
                // expected when receiver is stopped
                break;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to receive CoT packet");
            }
        }
    }
    
    private void ProcessData(byte[] data, IPEndPoint sender)
    {
        try
        {
            string xmlString = Encoding.UTF8.GetString(data);
            using var reader = new StringReader(xmlString);

            if (_serializer.Deserialize(reader) is CotEvent cotEvent)
            {
                _logger.LogDebug("Received CoT event from {Sender}: {Uid} ({Type}),", sender, cotEvent.Uid, cotEvent.Type);
                
                CotEventReceived?.Invoke(this, cotEvent);
            }
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Received malformed packet from {Sender}", sender);
        }
    }

    public void Dispose()
    {
        if (_isDisposed) return;
        _isDisposed = true;
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (disposing) Stop();
    }
}