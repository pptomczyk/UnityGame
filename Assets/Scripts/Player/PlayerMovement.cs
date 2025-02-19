using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movement_speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 mouseTarget;
    bool movingWithMouse;
    private SpriteRenderer sp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // wsad movement
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //mouse movement
        if(Input.GetMouseButtonDown(0))
        {
            mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movingWithMouse = true;
        }
        if(movingWithMouse && Vector2.Distance(transform.position, mouseTarget) < 0.1f)
        {
            movingWithMouse = false;
            this.rb.linearVelocity = Vector2.zero;
        }
        if(direction != Vector2.zero)
        {
            movingWithMouse = false;

        }
      
    }

    void FixedUpdate()
    {
        if(movingWithMouse)
        {
            Vector2 moveDirection = (mouseTarget - (Vector2)transform.position).normalized;
            this.rb.linearVelocity = moveDirection * movement_speed;
           
            if(moveDirection.x < 0) this.sp.flipX = true;
            if(moveDirection.x > 0) this.sp.flipX = false;
        }
        else
        {
            this.rb.linearVelocity = direction.normalized * movement_speed;
            if(direction.x < 0) this.sp.flipX = true;
            if(direction.x > 0) this.sp.flipX = false;   
        }     
    }
}
