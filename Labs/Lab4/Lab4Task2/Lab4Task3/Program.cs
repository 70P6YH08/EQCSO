using System.Security.Cryptography;

string defaultPath = "C:\\temp\\default\\directory";
string mirrorPath = "C:\\temp\\mirror\\directory";

List<string> dirPaths = new()
{
    defaultPath,
    mirrorPath
};

Console.Write("Введите путь к файлу: ");

string? filePath = Console.ReadLine();

while (!File.Exists(filePath))
{
    Console.WriteLine("Такого файла не существует!");
    filePath = Console.ReadLine();
}

string currentFileChecksum;

using (SHA256 sHA256 = SHA256.Create())
{
    byte[] hashBytes = sHA256.ComputeHash(File.OpenRead(filePath));
    string checksum = BitConverter.ToString(hashBytes).Replace("-", "");

    currentFileChecksum = filePath.Split(".").First() + ".checksum";
    File.WriteAllText(currentFileChecksum, checksum);
}

var newFileNamePart = filePath.Split('\\').Last().Split('.');
var newFileName = newFileNamePart[0] + "_copy." + newFileNamePart[1];

List<string> filePaths = new();

Parallel.ForEach(dirPaths, dirPath =>
{
    if (!Directory.Exists(dirPath))
    {
        Console.WriteLine($"Дректории {dirPath} не существует.\nФайлы не сохранены");
        return;
    }

    var newFilePath = Path.Combine(dirPath, newFileName);

    try
    {
        File.Copy(filePath, newFilePath, true);

        using (SHA256 sHA256 = SHA256.Create())
        {
            byte[] hashBytes = sHA256.ComputeHash(File.OpenRead(filePath));
            string checksum = BitConverter.ToString(hashBytes).Replace("-", "");

            var newFileChecksum = newFilePath.Split(".").First() + ".checksum";

            File.WriteAllTextAsync(newFileChecksum, checksum);

            filePaths.AddRange(currentFileChecksum, newFileChecksum);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
});

try
{
    var resultCompareHashes = CompareHashes(filePaths);

    if (resultCompareHashes.Item1)
        Console.WriteLine("Сохранение прошло удачно. Контрольные суммы файлов совпадают");
    else
        Console.WriteLine("Сохранение прошло неудачно:");

    foreach (var message in resultCompareHashes.Item2)
        Console.WriteLine($"\t - {message}");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

static (bool, string) CompareHashes(List<string> filePaths)
{
    if (!File.Exists(filePaths[0]) || !File.Exists(filePaths[1]))
        return (false, "Файлов не существует!");

    string hash1;
    string hash2;

    using (StreamReader streamReader = new(filePaths[0]))
        hash1 = streamReader.ReadToEnd();

    using (StreamReader streamReader = new(filePaths[1]))
        hash2 = streamReader.ReadToEnd();

    if (hash1.Length != hash2.Length)
        return(false, "Хэши разной длины");

    for (int i = 0; i < hash1.Length; i++)
    {
        if (hash1[i] != hash2[i])
            return (false, "Хэши различаются");
    }

    return (true, "Успешно");

    //var hash1 = await CalculateHash(currentFileChecksum);
    //var hash2 = await CalculateHash(newFileChecksum);


}

//async static Task<byte[]> CalculateHash(string filePath)
//{
//    using (FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read))
//    using (SHA256 sha256 = SHA256.Create())
//        return sha256.ComputeHash(fileStream);
//}