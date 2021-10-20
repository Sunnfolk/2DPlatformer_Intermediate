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
        public float m_JumpTime = .4f;
        
        public void Move(Rigidbody2D rigidbody2D, Vector2 input)
        {
            rigidbody2D.velocity = new Vector2(input.x * moveSpeed, rigidbody2D.velocity.y);
        }

        public void Jump(bool isGrounded, Rigidbody2D rigidbody2D, bool jumpInput)
        {
            if (!jumpInput) return;
            if (!isGrounded) return;
        
            m_IsJumping = true; //Long Jump
            m_JumpTimeCounter = m_JumpTime; // Long Jump
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }

        public void LongJump(float longJump, Rigidbody2D rigidbody2D)
        {
            print("Tier 0");
            if (longJump > 0f && m_IsJumping)
            {
                print("Tier 1");
                if (m_JumpTimeCounter > 0)
                {
                    print("Tier 2");
                    rigidbody2D.velocity = Vector2.up * jumpSpeed;
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