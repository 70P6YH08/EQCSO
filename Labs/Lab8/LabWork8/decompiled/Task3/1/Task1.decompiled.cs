using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using <PrivateImplementationDetails>{897362BD-4C64-44F4-9A5C-4E155FE31E57};

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
namespace A
{
	[CompilerGenerated]
	internal class A
	{
		private static void A(string[] P_0)
		{
			string value = EBB309D4-A1F4-4C10-B832-15A860A7C103.A();
			Console.WriteLine(EBB309D4-A1F4-4C10-B832-15A860A7C103.a());
			Console.Write(EBB309D4-A1F4-4C10-B832-15A860A7C103.B());
			string text = Console.ReadLine();
			string value2 = (text.Equals(value) ? EBB309D4-A1F4-4C10-B832-15A860A7C103.C() : EBB309D4-A1F4-4C10-B832-15A860A7C103.b());
			Console.WriteLine(value2);
		}
	}
}
namespace <PrivateImplementationDetails>{897362BD-4C64-44F4-9A5C-4E155FE31E57}
{
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	internal class EBB309D4-A1F4-4C10-B832-15A860A7C103
	{
		[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 95)]
		private struct 2
		{
		}

		internal static 2 3/* Not supported: data(DA CA DB DA D9 C0 DE C9 93 73 3F 71 18 77 1F 74 36 6B 0F 69 00 6F 0E 6D 02 62 32 61 03 67 0F 64 06 B1 A8 FB E1 E0 F8 5D 10 53 32 51 33 57 30 55 22 4A 1A 49 2B BF 4C 22 42 23 41 11 46 29 44 2E 3B 67 D2 C9 AF AC AF A8 B1 B0 BF A5 A3 A9 AD A0 BE BA BB BA BB AC AF A2 B5 A1 B1 BF A2 B2 B0) */;

		internal static byte[] 4 = new byte[95]
		{
			218, 202, 219, 218, 217, 192, 222, 201, 147, 115,
			63, 113, 24, 119, 31, 116, 54, 107, 15, 105,
			0, 111, 14, 109, 2, 98, 50, 97, 3, 103,
			15, 100, 6, 177, 168, 251, 225, 224, 248, 93,
			16, 83, 50, 81, 51, 87, 48, 85, 34, 74,
			26, 73, 43, 191, 76, 34, 66, 35, 65, 17,
			70, 41, 68, 46, 59, 103, 210, 201, 175, 172,
			175, 168, 177, 176, 191, 165, 163, 169, 173, 160,
			190, 186, 187, 186, 187, 172, 175, 162, 181, 161,
			177, 191, 162, 178, 176
		};

		internal static string[] 5 = new string[5];

		private static string 6(int P_0, int P_1, int P_2)
		{
			string text = Encoding.UTF8.GetString(4, P_1, P_2);
			5[P_0] = text;
			return text;
		}

		public static string A()
		{
			return 5[0] ?? 6(0, 0, 9);
		}

		public static string a()
		{
			return 5[1] ?? 6(1, 9, 30);
		}

		public static string B()
		{
			return 5[2] ?? 6(2, 39, 29);
		}

		public static string b()
		{
			return 5[3] ?? 6(3, 68, 13);
		}

		public static string C()
		{
			return 5[4] ?? 6(4, 81, 14);
		}

		static EBB309D4-A1F4-4C10-B832-15A860A7C103()
		{
			for (int i = 0; i < 4.Length; i++)
			{
				4[i] = (byte)(4[i] ^ i ^ 0xAA);
			}
		}
	}
}
