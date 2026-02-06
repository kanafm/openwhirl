namespace Core.World;

public readonly struct ChunkCoord
{
    public readonly int X;
    public readonly int Y;
    public readonly int Z;

    public ChunkCoord(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
