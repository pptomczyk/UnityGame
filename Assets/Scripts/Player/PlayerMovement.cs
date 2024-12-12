using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movement_speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 mouseTarget;
    bool movingWithMouse;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // wsad movement
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
            this.rb.linearVelocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if(movingWithMouse)
        {
            Vector2 moveDirection = (mouseTarget - (Vector2)transform.position).normalized;
            this.rb.linearVelocity = moveDirection * movement_speed;
        }
        else
        {
            this.rb.linearVelocity = direction.normalized * movement_speed;
        }
        
        
        
    }
}
