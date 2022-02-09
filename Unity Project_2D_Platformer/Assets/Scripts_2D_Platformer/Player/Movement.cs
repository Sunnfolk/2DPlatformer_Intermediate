using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts_2D_Platformer.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 4f;

        [SerializeField] private float jumpSpeed = 10f;
        
        /*JUMPING*/
        private bool _isJumping;
        private float _jumpTimeCounter;
        [FormerlySerializedAs("m_JumpTime")] public float mJumpTime = .4f;
        
        public void Move(Rigidbody2D rigidBody2D, Vector2 input)
        {
            rigidBody2D.velocity = new Vector2(input.x * moveSpeed, rigidBody2D.velocity.y);
        }

        public void Jump(bool isGrounded, Rigidbody2D rigidbody2D, bool jumpInput)
        {
            if (!jumpInput) return;
            if (!isGrounded) return;
        
            _isJumping = true; //Long Jump
            _jumpTimeCounter = mJumpTime; // Long Jump
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }

        public void LongJump(float longJump, Rigidbody2D rigidbody2D)
        {
            print("Tier 0");
            if (longJump > 0f && _isJumping)
            {
                print("Tier 1");
                if (_jumpTimeCounter > 0)
                {
                    print("Tier 2");
                    rigidbody2D.velocity = Vector2.up * jumpSpeed;
                    _jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    _isJumping = false;
                }
            }
            if (longJump <= 0f)
            {
                _isJumping = false;
            }
        }
    }
}