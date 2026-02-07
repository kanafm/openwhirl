using UnityEditor;
using UnityEngine;

public static class BuildScript
{
    public static void BuildMacOS()
    {
        var options = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Scenes/Main.unity" },
            locationPathName = "Build/VoxelWorld.app",
            target = BuildTarget.StandaloneOSX,
            options = BuildOptions.None
        };

        var report = BuildPipeline.BuildPlayer(options);

        if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.LogError("Build failed");
            EditorApplication.Exit(1);
        }

        Debug.Log("Build succeeded");
        EditorApplication.Exit(0);
    }
}
