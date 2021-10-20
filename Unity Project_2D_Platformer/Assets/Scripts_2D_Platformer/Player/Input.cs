using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class Input : MonoBehaviour
    {
        private CharacterInputMap _playerInput;

        private Vector2 _moveAxis;
        public Vector2 MoveAxis => _moveAxis;

        public float Jumping => _jumping;
        private float _jumping;

        public bool Jump => _jump;
        private bool _jump;

        private void Awake()
        {
            _playerInput = new CharacterInputMap();
        }

        private void Update()
        {
            _moveAxis = _playerInput.Player.Move.ReadValue<Vector2>();
            _jumping = _playerInput.Player.Jump.ReadValue<float>();
            _jump = _playerInput.Player.Jump.triggered;
        }


        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }
    }
}
