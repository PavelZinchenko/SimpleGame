﻿using UnityEngine;

namespace Characters
{
    public class CharacterStateMachine : MonoBehaviour
    {
        [SerializeField] private States.CharacterState _firstState;

        private Context _context = new();

        private States.CharacterState _currentState;

        private void Start()
        {
            Transit(_firstState);
        }

        private void Update()
        {
            if (_currentState == null)
                return;

            var nextState = _currentState.Transition;
            if (nextState != null)
                Transit(nextState);
        }

        public void OnLeftGround()
        {
            _context.Grounded = false;
        }

        public void OnSteppedOnGround()
        {
            _context.Grounded = true;
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

        private void Transit(States.CharacterState nextState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(_context);
        }
    }
}