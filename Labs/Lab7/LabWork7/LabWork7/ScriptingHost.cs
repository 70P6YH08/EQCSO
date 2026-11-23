using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Windows;
using Task1;

namespace LabWork7
{
    public class ScriptingHost(EventService eventService)
    {
        private ScriptOptions _scriptOptions = ScriptOptions.Default
            .WithReferences(AppDomain.CurrentDomain.GetAssemblies())
            .WithImports("System", "System.Collections.Generic", "System.Linq");

        public async Task ExecuteAsync(string code)
        {
            try
            {
                await CSharpScript.EvaluateAsync(code, _scriptOptions, new Automation(eventService));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            using (var reader = new StreamReader(server))
            {
                string? line;
                while (true)
                {
                    line = await reader.ReadLineAsync();

                    if (line == null)
                        break;

                    await ExecuteAsync(line);
                }
            }
        }
    }
}
