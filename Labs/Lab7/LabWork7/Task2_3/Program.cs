
using System.IO.Pipes;

using (var pipe = new NamedPipeClientStream(".", "mypipe", System.IO.Pipes.PipeDirection.Out))
{
    pipe.Connect();
    using (var writer = new StreamWriter(pipe))
    {
        while (true)
        {
            if (ConsoleKey.Escape == Console.ReadKey(true).Key)
                break;

            writer.WriteLine(Console.ReadLine());
            writer.Flush();
        }
        writer.Close();
        pipe.Close();
    }
}
