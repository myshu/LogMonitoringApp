using LogMonitorigApp.Infrastructure;

Console.WriteLine("App started.");

try
{
    var path = "Resources/";
    Logger.Run(path);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("Closing app...");