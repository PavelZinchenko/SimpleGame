using UnityEngine;

namespace Characters
{
    public interface IContext
    {
        Vector2 MovementDirection { get; }
        bool WantToJump { get; }
        bool Grounded { get; }
        bool MustDie { get; }
    }

    public class Context : IContext
    {
        public Vector2 MovementDirection { get; set; }
        public bool WantToJump { get; set; }
        public bool Grounded { get; set; } = true;
        public bool MustDie { get; set; }
    }
}
