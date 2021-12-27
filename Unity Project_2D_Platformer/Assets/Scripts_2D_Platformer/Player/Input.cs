using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class Input : MonoBehaviour
    {
        private CharacterInputMap _playerInput;

        public Vector2 MoveAxis { get; private set; }

        public float Jumping { get; private set; }

        public bool Jump { get; private set; }

        private void Awake() => _playerInput = new CharacterInputMap();

        private void Update()
        {
            MoveAxis = _playerInput.Player.Move.ReadValue<Vector2>();
            Jumping = _playerInput.Player.Jump.ReadValue<float>();
            Jump = _playerInput.Player.Jump.triggered;
        }

        private void OnEnable() => _playerInput.Enable();

        private void OnDisable() => _playerInput.Disable();
    }
}