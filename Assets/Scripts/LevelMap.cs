using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelMap
{
    private Tilemap _tilemap;

    public void SetGroundMap(Tilemap tilemap)
    {
        _tilemap = tilemap;
    }

    public Vector3Int WorldToCell(Vector3 position) => _tilemap.WorldToCell(position);
    public bool HasTile(Vector3Int cell) => _tilemap.HasTile(cell);
}
