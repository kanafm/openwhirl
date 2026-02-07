using Core.Noise;

namespace Core.World {
    public static class ChunkGenerator {
        public const int ChunkSize = 16;

        public static float[] GenerateDensity(ChunkCoord coord, WorldSeed seed) {
            var data = new float[ChunkSize * ChunkSize * ChunkSize];

            for (int x = 0; x < ChunkSize; x++)
            for (int y = 0; y < ChunkSize; y++)
            for (int z = 0; z < ChunkSize; z++) {
                int wx = coord.X * ChunkSize + x;
                int wy = coord.Y * ChunkSize + y;
                int wz = coord.Z * ChunkSize + z;

                float height = ValueNoise.Sample(wx / 64, 0, wz / 64, seed.Value) * 10f;
                float density = height - wy;

                data[x + ChunkSize * (y + ChunkSize * z)] = density;
            }

            return data;
        }
    }
}