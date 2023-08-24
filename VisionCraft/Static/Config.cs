using System.ComponentModel;

namespace VisionCraft.Static {
    public static class Config {
        public static bool IsProjectOpened { get; set; } = false;

        public static string ProjectName { get; set; }
        public static string ProjectPath { get; set; }
    }
}
