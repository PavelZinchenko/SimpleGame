using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameLevel
{
    public class LevelMap : MonoBehaviour, ILevelMap
    {
        [SerializeField] private Tilemap _floor;
        [SerializeField] private Tilemap _walls;

        public IEnumerable<Vector2> GetRandomTiles(int count)
        {
            throw new System.NotImplementedException();
        }

        public bool HasFloor(Vector2 position)
        {
            var cell = _floor.WorldToCell(position);
            return _floor.HasTile(cell);
        }

        public void AssignToCharacter(Characters.CharacterConfigurator character)
        {
            character.AssignLevelMap(this);
        }
    }
}
