using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
[assembly: AssemblyCompany("Task1")]
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+a5fcce75f768d533246aff07d970ba1821fb844a")]
[assembly: AssemblyProduct("Task1")]
[assembly: AssemblyTitle("Task1")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: RefSafetyRules(11)]
namespace 돭;

[CompilerGenerated]
internal class 돭
{
	private static void 돭(string[] P_0)
	{
		string value = "password1";
		Console.WriteLine("Пользователь: root");
		Console.Write("Введите пароль: ");
		string text = Console.ReadLine();
		string value2 = (text.Equals(value) ? "ACCESS_GRANTED" : "ACCESS_DENIED");
		Console.WriteLine(value2);
	}
}
