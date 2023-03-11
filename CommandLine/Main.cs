using System.IO.Pipes;

using var server = new NamedPipeServerStream("RealtimeOSpipe");
server.WaitForConnection();

using var sw = new StreamWriter(server);
sw.AutoFlush = true;

while (true)
{
    Console.Write("Команда: ");
    var cmd = Console.ReadLine();
    sw.WriteLine(cmd);
}