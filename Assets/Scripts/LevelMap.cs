using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelMap
{
    private readonly Tilemap _tilemap;

    public LevelMap(Tilemap tilemap)
    {
        _tilemap = tilemap;
    }

    public Vector3Int WorldToCell(Vector3 position) => _tilemap.WorldToCell(position);
    public bool HasTile(Vector3Int cell) => _tilemap.HasTile(cell);
}
