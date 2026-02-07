using System.Collections.Generic;
using UnityEngine;
using Core.World;

public static class VoxelMesher
{
    public static Mesh BuildMesh(float[] density)
    {
        var verts = new List<Vector3>();
        var tris = new List<int>();

        int size = ChunkGenerator.ChunkSize;

        for (int x = 0; x < size; x++)
        for (int y = 0; y < size; y++)
        for (int z = 0; z < size; z++)
        {
            int i = x + size * (y + size * z);
            if (density[i] < 0) continue;

            AddCube(verts, tris, new Vector3(x, y, z));
        }

        var mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        mesh.SetVertices(verts);
        mesh.SetTriangles(tris, 0);
        mesh.RecalculateNormals();
        return mesh;
    }

    static void AddCube(List<Vector3> v, List<int> t, Vector3 p)
    {
        int i = v.Count;

        v.AddRange(new[]
        {
            p + new Vector3(0,0,0), p + new Vector3(1,0,0),
            p + new Vector3(1,1,0), p + new Vector3(0,1,0),
            p + new Vector3(0,0,1), p + new Vector3(1,0,1),
            p + new Vector3(1,1,1), p + new Vector3(0,1,1),
        });

        int[] faces =
        {
            0,2,1, 0,3,2,
            4,5,6, 4,6,7,
            0,1,5, 0,5,4,
            2,3,7, 2,7,6,
            0,4,7, 0,7,3,
            1,2,6, 1,6,5
        };

        foreach (var f in faces) t.Add(i + f);
    }
}
