using UnityEngine;
using Core.World;

public class Bootstrap : MonoBehaviour
{
    void Start()
    {
        var camGO = new GameObject("Main Camera");
        var cam = camGO.AddComponent<Camera>();
        cam.tag = "MainCamera";
        cam.transform.position = new Vector3(20, 20, -20);
        cam.transform.LookAt(Vector3.zero);

        var lightGO = new GameObject("Light");
        var light = lightGO.AddComponent<Light>();
        light.type = LightType.Directional;
        lightGO.transform.rotation = Quaternion.Euler(50, 30, 0);

        var seed = new WorldSeed(1337);
        var coord = new ChunkCoord(0, 0, 0);
        var density = ChunkGenerator.GenerateDensity(coord, seed);
        var mesh = VoxelMesher.BuildMesh(density);

        var world = new GameObject("VoxelChunk");
        var mf = world.AddComponent<MeshFilter>();
        var mr = world.AddComponent<MeshRenderer>();
        mf.mesh = mesh;
        mr.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

        world.AddComponent<Spin>();
    }
}
