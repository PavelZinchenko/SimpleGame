using UnityEngine;

namespace StateMachine.Character
{
    public class StateMachine : Base.StateMachine<IContext>
    {
        private readonly Context _context = new();

        protected override IContext Context => _context;

        public void Move(Vector2 direction)
        {
            _context.MovementDirection = direction;
        }

        public void Jump(bool pressed)
        {
            _context.WantToJump = pressed;
        }

        public void Die()
        {
            _context.MustDie = true;
        }
    }
}
