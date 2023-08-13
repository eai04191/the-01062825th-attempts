using System.Linq;
using HadakaCoat.Scripts.OutGame;
using HarmonyLib;
using UnityEngine;

namespace Un175;

[HarmonyPatch(typeof(TitleSceneView), nameof(TitleSceneView.Start))]
class TitleScenePatch
{
    [HarmonyPostfix]
    static void ShaderPatch()
    {
        var shaderType = Il2CppInterop.Runtime.Il2CppType.Of<Shader>();
        var list = Object
            .FindObjectsOfTypeAll(shaderType)
            .ToList()
            .FindAll(shader => shader.name == "FX/Censor");

        foreach (var shader in list)
        {
            Plugin.Log.LogInfo($"Found FX/Censor Shader, destroying it...");
            Object.Destroy(shader);
        }
    }

    [HarmonyPostfix]
    static void MosaicPatch()
    {
        var goType = Il2CppInterop.Runtime.Il2CppType.Of<GameObject>();
        var list = Resources
            .FindObjectsOfTypeAll(goType)
            .ToList()
            .FindAll(go => go.name.Contains("Mosaic"))
            .Select(go => go.TryCast<GameObject>());

        foreach (var go in list)
        {
            Plugin.Log.LogInfo($"Found GameObject: {go.name}, disabling it...");
            go.SetActive(false);
        }
    }
}
