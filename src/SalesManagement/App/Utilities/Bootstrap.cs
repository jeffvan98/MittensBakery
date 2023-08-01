namespace MittensBakery.SalesManagement.App.Utilities;

public static class Bootstrap
{
    public static void InitiailizeEnvironmentVariables(string path)
    {
        if (File.Exists(path))
        {
            foreach(var line in File.ReadAllLines(path))
            {
                var parts = line.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    Environment.SetEnvironmentVariable(parts[0], parts[1]);
                }
            }
        }
    }
}