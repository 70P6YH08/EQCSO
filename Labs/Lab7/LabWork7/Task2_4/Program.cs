var pipeClient = new System.IO.Pipes.NamedPipeServerStream("mypipe", System.IO.Pipes.PipeDirection.In);
pipeClient.WaitForConnection();
using (var streamReader = new StreamReader(pipeClient))
{
    string response = streamReader.ReadLine();
    Console.WriteLine(response);
}