using System.Security.Principal;

using WindowsIdentity identity = WindowsIdentity.GetCurrent();

var principal = new WindowsPrincipal(identity);

Console.WriteLine(principal.Identity.Name); // имя текущего пользователя
Console.WriteLine(principal.Identity.IsAuthenticated); // имя пользователя
foreach(var item in identity.Groups)
    Console.WriteLine(item.Translate(typeof(NTAccount)).Value);

