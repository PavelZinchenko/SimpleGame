﻿using UnityEngine;

namespace StateMachine.Character
{
    public class StateMachine : Base.StateMachine<IContext>
    {
        private readonly Context _context = new();

        protected override IContext Context => _context;

        public void SetCallback(ICallback callback)
        {
            _context.Callback = callback;
        }

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

        public void Hit()
        {
            _context.GotHit = true;
        }

        protected override void OnUpdated()
        {
            _context.GotHit = false;
        }
    }
}
