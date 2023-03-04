using System.Net.NetworkInformation;

// Set the buffer size to a larger value (e.g. 65536)
int bufferSize = 65536;
byte[] buffer = new byte[bufferSize];

// Call the GetAllNetworkInterfaces method with the larger buffer size
NetworkInterface.GetAllNetworkInterfaces().ForEach(ni =>
{
    try
    {
        IPInterfaceProperties ipProperties = ni.GetIPProperties();
        IPv4InterfaceStatistics statistics = ni.GetIPv4Statistics();
        PhysicalAddress mac = ni.GetPhysicalAddress();
        Console.WriteLine($"{ni.Name} ({ni.Description})");
        Console.WriteLine($"  MAC Address: {mac}");
        Console.WriteLine($"  IPv4 Statistics:");
        Console.WriteLine($"    Bytes Received: {statistics.BytesReceived}");
        Console.WriteLine($"    Bytes Sent: {statistics.BytesSent}");
        Console.WriteLine($"    Unicast Packets Received: {statistics.UnicastPacketsReceived}");
        Console.WriteLine($"    Unicast Packets Sent: {statistics.UnicastPacketsSent}");
        Console.WriteLine($"    Non-Unicast Packets Received: {statistics.NonUnicastPacketsReceived}");
        Console.WriteLine($"    Non-Unicast Packets Sent: {statistics.NonUnicastPacketsSent}");
        Console.WriteLine($"    Incoming Packets Discarded: {statistics.IncomingPacketsDiscarded}");
        Console.WriteLine($"    Outgoing Packets Discarded: {statistics.OutgoingPacketsDiscarded}");
        Console.WriteLine($"    Incoming Packets with Errors: {statistics.IncomingPacketsWithErrors}");
        Console.WriteLine($"    Outgoing Packets with Errors: {statistics.OutgoingPacketsWithErrors}");
        Console.WriteLine($"    Incoming Unknown Protocol Packets: {statistics.IncomingUnknownProtocolPackets}");
    }
    catch (NetworkInformationException ex)
    {
        // Handle exception
        Console.WriteLine($"Error retrieving information for network interface {ni.Name}: {ex.Message}");
    }
});
