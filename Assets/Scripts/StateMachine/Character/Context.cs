using UnityEngine;

namespace StateMachine.Character
{
    public interface IContext
    {
        Vector2 MovementDirection { get; }
        bool WantToJump { get; }
        bool MustDie { get; }
        bool GotHit { get; }
        ICallback Callback { get; }
    }

    public interface ICallback
    {
        void OnFellDown();
        void OnDied();
    }

    public class Context : IContext
    {
        public Vector2 MovementDirection { get; set; }
        public bool WantToJump { get; set; }
        public bool MustDie { get; set; }
        public bool GotHit { get; set; }
        public ICallback Callback { get; set; }
    }
}
