using System;
using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class CharacterController : MonoBehaviour
    {
        #region REFERENCE VARIABLES
        private Rigidbody2D _rigidBody2D;
        private Input _Input;
        private Movement _move;
        private Collisions _Collisions;
        private Animations _Animations;
        #endregion

        private enum States { Start, Ground, Air, Dash, Pause, CutScene };

        [SerializeField] private States state;

        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _Input = GetComponent<Input>();
            _move = GetComponent<Movement>();
            _Collisions = GetComponent<Collisions>();
            _Animations = GetComponent<Animations>();
            state = States.Start;
        }

        private void Update()
        {
            if (state is States.Pause or States.CutScene) return;
            
            switch (state)
            {
                case States.Start:
                    /* Change State Below */
                    state = _Collisions.isGrounded ? States.Ground : States.Air;
                    break;
                case States.Ground:
                    GroundEvents();
                    /* Change State Below */
                    if (!_Collisions.isGrounded) { state = States.Air; } 
                    break;
                case States.Air:
                    AirEvents();
                    /* Change State Below */
                    if (_Collisions.isGrounded) { state = States.Ground; }
                    break;
                case States.Dash:
                    break;
                case States.Pause:
                    break;
                case States.CutScene:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void FixedUpdate()
        {
            if (state is States.Start or States.Pause or States.CutScene) return;
            _move.Move(_rigidBody2D, _Input.MoveAxis);
        }

        private void GroundEvents()
        {
            _move.Jump(_Collisions.isGrounded, _rigidBody2D, _Input.Jump);
            _Animations.GroundAnimations();
        }

        private void AirEvents()
        {
            _move.LongJump(_Input.Jumping, _rigidBody2D);
            _Animations.AirAnimations();
        }
    }
}