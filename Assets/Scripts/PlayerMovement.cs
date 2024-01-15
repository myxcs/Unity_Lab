using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private float dirX = 0f;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f; 
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

   //enum
    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
  private void Start()
   {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       sprite = GetComponent<SpriteRenderer>();
       coll = GetComponent<BoxCollider2D>();
    
   }
   private void Update() {
 
       //di chuyển trái phải, phần input ngó lại trong edit/ project setting/ input manager.
       //lệnh GetAxisRaw làm nhân vật không bị trượt
       dirX = Input.GetAxisRaw("Horizontal");
       //vẫn chưa hiểu lắm nhưng nên nhân dirX (direct x) với 7f, phần rb.velocity.y để cập nhật vị trí nhảy
       rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


      if (Input.GetButtonDown("Jump") && IsGrounded())
      {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      }

      //animation
      UpdateAnimation();
    
   }

   private void UpdateAnimation()
   {
    MovementState state = MovementState.idle;
  if (dirX > 0f)
      {
        state = MovementState.running;
        //xoay khi đổi hướng
        sprite.flipX = false;
      }
      else if (dirX < 0f)
      {
        state = MovementState.running;
        sprite.flipX = true;

      }
      else 
      {
        state = MovementState.idle;
      }

         //Mathf.Epsilon = tiny float number
       if (rb.velocity.y > .1f)
       {
        state = MovementState.jumping;
       }
       else if (rb.velocity.y < -.1f)
       {
        state = MovementState.falling;
       }

      animator.SetInteger("state",(int)state );
      //ép kiểu int
      //set state theo chuyển động nhân vật
   }

   //check standing ground
   private bool IsGrounded()
   {
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    //boxcast để kiểm tra 
   }
}
