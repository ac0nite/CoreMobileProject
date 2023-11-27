using System.Diagnostics;

namespace Application
{
    public static class Log 
    {
        [Conditional("ENABLE_LOGS")]
        public static void Debug(string logMsg) => UnityEngine.Debug.Log(logMsg);
        
        [Conditional("ENABLE_LOGS")]
        public static void Debug(Prefix prefix, string logMsg) => UnityEngine.Debug.Log($"[{prefix.Value}] {logMsg}");
        public static void Warning(string logMsg) => UnityEngine.Debug.LogWarning(logMsg);
        public static void Warning(Prefix prefix, string logMsg) => UnityEngine.Debug.LogWarning($"[{prefix.Value}] {logMsg}");

        public static void Error(string logMsg) => UnityEngine.Debug.LogError(logMsg);
        public static void Error(Prefix prefix, string logMsg) => UnityEngine.Debug.LogError($"[{prefix.Value}] {logMsg}");
    }
    
    public partial class Prefix
    {
        public static readonly Prefix Installer = new Prefix() {Value = "installer"};
        public static readonly Prefix FSM = new Prefix() {Value = "fsm"};
        public static readonly Prefix Scene = new Prefix() {Value = "scene"};
        public static readonly Prefix Service = new Prefix() {Value = "service"};
        public static readonly Prefix Screen = new Prefix() {Value = "screen"};
        public static readonly Prefix Popup = new Prefix() {Value = "popup"};

        public string Value { get; private set; }
    }
}