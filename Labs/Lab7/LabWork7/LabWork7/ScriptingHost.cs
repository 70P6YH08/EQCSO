using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace LabWork7
{
    public class ScriptingHost
    {
        private ScriptOptions scriptOptions = ScriptOptions.Default
            .WithReferences(AppDomain.CurrentDomain.GetAssemblies())
            .WithImports("System", "System.Collections.Generic", "System.Linq");

        public async Task ExecuteAsync(string code)
        {
            await CSharpScript.EvaluateAsync(code, scriptOptions, new Automation());
        }

        public async Task Run()
        {
            while (true)
            {
                using (NamedPipeServerStream server = new NamedPipeServerStream("mypipe", PipeDirection.In))
                {
                    server.WaitForConnection();
                    await HandleClient(server);
                }
            }
        }

        private async Task HandleClient(NamedPipeServerStream server)
        {
            using var reader = new StreamReader(server);
            using var writer = new StreamWriter(server, Encoding.UTF8, 8192, false);
            writer.AutoFlush = true;

            while (true)
            {
                string line = await reader.ReadLineAsync();
                if (line == null) break; // Клиент закрыл соединение

                Console.WriteLine("Received: " + line);

                await writer.WriteLineAsync("Echo: " + line);
            }
        }
    }
}
