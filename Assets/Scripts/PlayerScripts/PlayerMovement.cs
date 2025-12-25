using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed ;
    public DynamicJoystick joystick;
    private Rigidbody2D rb;
    private bool isSwimming = true;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = PlayerStats.Speed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();   
        Flip();
    }
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        if (rb.linearVelocityX > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (rb.linearVelocityX < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    private void MovePlayer()
    {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        if (joystick != null)
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
        }

        Vector2 movement = new Vector2(x, y).normalized;
        rb.linearVelocity = movement * speed;

        if(x != 0 || y != 0)
        {
            animator.SetBool("swim",isSwimming);
        }else
        {
            animator.SetBool("swim",!isSwimming);
        }
    }
}
