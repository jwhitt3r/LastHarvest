namespace Economy
{
    public readonly struct MaterialCost
    {
        public int Wood { get; }
        public int Scrap { get; }

        public MaterialCost(int wood, int scrap)
        {
            Wood = wood;
            Scrap = scrap;
        }
    }
}