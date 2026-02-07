using Core.Biomes;
using Core.World;

var seed = new WorldSeed(12345);

for (int x = 0; x < 5; x++)
{
    for (int z = 0; z < 5; z++)
    {
        var t = BiomeFields.Temperature(x * 64, z * 64, seed.Value);
        var h = BiomeFields.Humidity(x * 64, z * 64, seed.Value);
        System.Console.WriteLine($"({x},{z}) temp={t:F2} humid={h:F2}");
    }
}
