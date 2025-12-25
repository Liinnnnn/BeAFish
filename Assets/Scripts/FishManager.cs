using Unity.Collections;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] public int exp;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(speed,speed*2f);
        int randomScale = Random.Range(1,3);
        transform.localScale = new Vector3(randomScale,randomScale);
        if(transform.position.x > 0)
        {
            Flip(false);
        }else {
            Flip(true);
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2( 5 * -speed ,rb.linearVelocity.y) * Time.deltaTime);
    }

    private void Flip(bool IsFacingRight)
    {
        Vector3 scale = transform.localScale;
        if (IsFacingRight)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    
}
