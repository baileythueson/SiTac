using SiTacLib.Models.CoT;

namespace SiTacLib.Networking;

/// <summary>
/// Represents an interface for receiving Cursor on Target (CoT) events over a network connection.
/// Implementations of this interface define mechanisms to receive, deserialize, and process CoT events.
/// </summary>
public interface ICotReceiver
{
    /// <summary>
    /// Occurs when a new Cursor on Target (CoT) event has been received.
    /// This event provides a mechanism for subscribers to handle or process
    /// the incoming CoT event data.
    /// </summary>
    event EventHandler<CotEvent> CotEventReceived;

    /// <summary>
    /// Starts the process of listening for Cursor on Target (CoT) events on the specified UDP port.
    /// </summary>
    /// <param name="port">The UDP port number on which to listen for incoming CoT events.</param>
    /// <remarks>
    /// This method initializes the UDP client, begins the asynchronous listening loop, and handles incoming
    /// CoT events. If the process has already started, subsequent calls to this method will have no effect.
    /// In case of a failure to bind to the specified port (e.g., due to permissions or the port being in use),
    /// a <see cref="SocketException"/> is thrown. Ensure proper resource cleanup by calling <see cref="Stop"/>
    /// after usage.
    /// </remarks>
    /// <exception cref="SocketException">
    /// Thrown when there's an issue binding to the specified UDP port.
    /// </exception>
    void Start(int port);

    /// <summary>
    /// Stops the process of listening for Cursor on Target (CoT) events and releases associated resources.
    /// </summary>
    /// <remarks>
    /// This method halts the asynchronous listening loop, terminates the UDP client, and ensures proper cleanup
    /// of network resources. Calling this method when the receiver is not running will have no effect.
    /// After calling <see cref="Stop"/>, the receiver must be re-initialized using <see cref="Start"/> before
    /// it can resume listening for CoT events.
    /// </remarks>
    void Stop();
}