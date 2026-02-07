namespace Core.Noise {
    public static class ValueNoise  {
        public static float Sample(int x, int y, int z, int seed) {
            unchecked
            {
                int h = seed;
                h = h * 31 + x;
                h = h * 31 + y;
                h = h * 31 + z;
                h ^= h >> 13;
                return (h & 0xFFFF) / 65535.0f;
            }
        }
    }
}
