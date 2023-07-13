using UnityEngine;

namespace StateMachine.Character
{
    public interface IContext
    {
        Vector2 MovementDirection { get; }
        bool WantToJump { get; }
        bool MustDie { get; }
    }

    public class Context : IContext
    {
        public Vector2 MovementDirection { get; set; }
        public bool WantToJump { get; set; }
        public bool MustDie { get; set; }
    }
}
