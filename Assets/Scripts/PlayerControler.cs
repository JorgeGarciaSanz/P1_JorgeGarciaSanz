using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 2.5f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 2.5f;
    [SerializeField] private bool enableDoubleJump = false;

    private Rigidbody rb;

    
    private bool isGrounded = false;
    private bool hasDoubleJumped = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        posicionRespawn = transform.position;
    }

    private void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                hasDoubleJumped = false; 
            }
            else if (enableDoubleJump && !hasDoubleJumped)
            {
                Jump();
                hasDoubleJumped = true; 
            }
        }
    }

    private void Jump()
    {
        
        Vector3 v = rb.linearVelocity; 
        v.y = 0f;
        rb.linearVelocity = v;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasDoubleJumped = false; 
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private Vector3 posicionRespawn;



public void Respawn()
{
    transform.position = posicionRespawn;

    rb.linearVelocity = Vector3.zero; 
    rb.angularVelocity = Vector3.zero;
}
}
