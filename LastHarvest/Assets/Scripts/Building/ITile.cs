using UnityEngine;

namespace Building
{
    public interface ITile
    {
        public GameObject Object { get; }
        
        public TileDimension Size { get; }
    }
}