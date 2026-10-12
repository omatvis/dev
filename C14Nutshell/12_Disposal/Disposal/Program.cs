namespace Disposal
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // get User folder path
            var folderApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var applicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var userFolderPath = Path.Combine(folderApplicationData, applicationName ?? "Disposal");
            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(userFolderPath);
            }
            var userFile = Path.Combine(userFolderPath, "example.txt");
            using (FileStream fs = new FileStream(userFile, FileMode.OpenOrCreate))
            using (TextWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine("Hello, world!");
            }


            using (FileStream fs = new FileStream(userFile, FileMode.Open))
            using (TextReader reader = new StreamReader(fs))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
            if (File.Exists(userFile)) File.Delete(userFile);
            if (Directory.Exists(userFolderPath)) Directory.Delete(userFolderPath);

        }
    }
}
