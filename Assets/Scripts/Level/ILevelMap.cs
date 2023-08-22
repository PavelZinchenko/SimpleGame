using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public enum TileType
    {
        Empty,
        Floor,
        Wall,
    }

    public interface ILevelMap
    {
        bool HasFloor(Vector2 position);
        IEnumerable<Vector2> GetRandomTiles(int count);
    }
}
