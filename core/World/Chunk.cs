namespace Core.World {
    public sealed class Chunk {
        public readonly ChunkCoord Coord;
        public readonly float[] DensityField;

        public Chunk(ChunkCoord coord, float[] densityField) {
            Coord = coord;
            DensityField = densityField;
        }
    }
}
