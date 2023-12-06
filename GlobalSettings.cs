namespace AdventOfCode2023
{
    public static class GlobalSettings
    {
        public static bool EnableVisualizations { get; set; }

        public static void LoadFromCommands(Dictionary<char, string> commands)
        {
           EnableVisualizations = commands.ContainsKey('v');
        }
    }
}