using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class Collisions : MonoBehaviour
    {
        [SerializeField] private LayerMask _whatIsGround;
        public LayerMask whatIsGround => _whatIsGround;

        public bool isGrounded => _isGrounded();
        
        private bool _isGrounded()
        {
            var position = transform.position;
            var direction = Vector2.down;
            const float distance = 1.1f;
        
            Debug.DrawRay(position, direction, new Color(1f, 0f, 1f));
            var hit = Physics2D.Raycast(position, direction, distance, _whatIsGround);
        
            return hit.collider != null;
        }
    }
}
