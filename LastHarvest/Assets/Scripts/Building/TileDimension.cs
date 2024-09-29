namespace Building
{
    public struct TileDimension
    {
        public int X { get; }
        public int Y { get; }

        public TileDimension(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}