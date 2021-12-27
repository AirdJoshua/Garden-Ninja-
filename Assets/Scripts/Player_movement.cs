using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator anime;
    private float dirx = 0f;



    [SerializeField] private LayerMask jumpg;
    private SpriteRenderer sprite;
    [SerializeField] private float speed = 7f;
    [SerializeField]  private float jumpf = 14f;

    private enum MovementState { idle,running,jumping,falling}
    

    // Start is called before the first frame update
   private  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {

        dirx = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirx*speed,rb.velocity.y);

       


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpf, 0);
        }

    

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {

        MovementState state;
        if (dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else
        if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anime.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {
       return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpg);
    }
    
}
