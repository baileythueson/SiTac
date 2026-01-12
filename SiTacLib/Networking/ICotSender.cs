using SiTacLib.Models.CoT;

namespace SiTacLib.Networking;

/// <summary>
/// Represents an interface for sending Cursor-on-Target (CoT) messages over a network.
/// This interface defines the contract for sending CoTEvent data to a specified IP address and port.
/// </summary>
public interface ICotSender
{
    /// <summary>
    /// Sends a Cursor-on-Target (CoT) event asynchronously to the specified IP address and port over the network.
    /// </summary>
    /// <param name="cotEvent">The CoTEvent object that represents the CoT message to be sent.</param>
    /// <param name="ipAddress">The target IP address to which the CoT message is sent.</param>
    /// <param name="port">The port number of the target endpoint.</param>
    /// <returns>A task representing the asynchronous send operation.</returns>
    Task SendAsync(CotEvent cotEvent, string ipAddress, int port);
}