using UnityEngine;

public static class AutoBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Init()
    {
        var go = new GameObject("Bootstrap");
        go.AddComponent<RuntimeConfig>();
        go.AddComponent<Bootstrap>();
    }
}
