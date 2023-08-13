using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace Un175;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal new static ManualLogSource Log;

    public override void Load()
    {
        Log = base.Log;
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
    }
}
