using Core.Noise;

namespace Core.Biomes;

public static class BiomeFields
{
    public static float Temperature(int x, int z, int seed)
        => ValueNoise.Sample(x / 128, 0, z / 128, seed + 1);

    public static float Humidity(int x, int z, int seed)
        => ValueNoise.Sample(x / 128, 0, z / 128, seed + 2);

    public static float Continentalness(int x, int z, int seed)
        => ValueNoise.Sample(x / 512, 0, z / 512, seed + 3);
}
