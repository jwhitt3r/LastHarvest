using Util;

namespace Building
{
    public sealed class WorldGrid
    {
        private readonly GridCell[,] _cells;
        
        public int Width => _cells.GetLength(0);
        
        public int Height => _cells.GetLength(1);

        public WorldGrid(int width, int height)
        {
            _cells = new GridCell[width, height];
            InitialiseCells();
        }

        private void InitialiseCells()
        {
            var width = Width;
            var height = Height;
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    _cells[x, y] = new GridCell();
                }
            }
        }

        public bool CanPlaceTile(ITile tile, int xStart, int yStart)
        {
            for (var x = xStart; x < xStart + tile.Size.X; x++)
            {
                for (var y = yStart; y < yStart + tile.Size.Y; y++)
                {
                    if (_cells[x, y].IsOccupied) return false;
                }
            }

            return true;
        }

        public Result<string> PlaceTile(ITile tile, int xStart, int yStart)
        {
            if (!CanPlaceTile(tile, xStart, yStart)) return "Can't place tile";
            
            for (var x = xStart; x < xStart + tile.Size.X; x++)
            {
                for (var y = yStart; y < yStart + tile.Size.Y; y++)
                {
                    _cells[x, y].OccupyingTile = tile;
                }
            }

            return Result<string>.Ok();
        }

        private class GridCell
        {
            public ITile OccupyingTile { get; set; }
            
            public bool IsOccupied => OccupyingTile != null;
        }
    }

}