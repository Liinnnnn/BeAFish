using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed ;
    [SerializeField] public float size ;
    public DynamicJoystick joystick;
    private Rigidbody2D rb;
    private bool isSwimming = true;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (joystick == null)
        {
            joystick = FindAnyObjectByType<DynamicJoystick>();
        }
        speed = PlayerStats.Speed;
        size = PlayerStats.Size;
        transform.localScale = new Vector3(size,size);
        LevelUpUI.onUpgrade +=updateStats;
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
        float x;
        float y;
       
        if (joystick != null)
        {
            x = joystick.Horizontal;
            y = joystick.Vertical;
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
    private void updateStats()
    {
        size = PlayerStats.Size;
        speed = PlayerStats.Speed;
        transform.localScale = new Vector3(size,size);
    }
}
