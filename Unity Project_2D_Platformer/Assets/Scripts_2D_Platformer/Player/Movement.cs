using UnityEngine;

namespace Scripts_2D_Platformer.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4f;

        [SerializeField] private float jumpSpeed = 10f;
        
        /*JUMPING*/
        private bool m_IsJumping = false;
        private float m_JumpTimeCounter;
        private readonly float m_JumpTime = 0.25f;
        
        public void Move(Rigidbody2D _rigidbody2D, Vector2 _input)
        {
            _rigidbody2D.velocity = new Vector2(_input.x * moveSpeed, _rigidbody2D.velocity.y);
        }

        public void Jump(bool isgrounded, Rigidbody2D _rigidbody2D, bool jumpInput)
        {
            if (!jumpInput) return;
            if (!isgrounded) return;
        
            m_IsJumping = true; //Long Jump
            m_JumpTimeCounter = m_JumpTime; // Long Jump
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
        }

        public void LongJump(float longJump, Rigidbody2D _rigidbody2D)
        {
            if (longJump > 0f && m_IsJumping)
            {
                if (m_JumpTimeCounter > 0)
                {
                    _rigidbody2D.velocity = Vector2.up * jumpSpeed;
                    m_JumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    m_IsJumping = false;
                }
            }
            if (longJump <= 0f)
            {
                m_IsJumping = false;
            }
        }
    }
    
    public class Dash : Movement
    {
        public bool isDashing;
    }
    
    
    
}