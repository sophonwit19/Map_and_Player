using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    private GatherInput gatherInput;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    public float jumpForce;
    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
    }

    private int direction = 1; // to right-hand side

    void FixedUpdate()
    {
        CheckStatus();
        Move();
        JumpPlayer();
    }

    private void Move()
    {
        Flip();
        rigidbody2D.linearVelocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.linearVelocity.y);
    }

    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues()
    {
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
        // เปลี่ยนมาใช้ linearVelocity เพื่อให้โค้ดทันสมัยขึ้น
        animator.SetFloat("vSpeed", rigidbody2D.linearVelocity.y);
        animator.SetBool("Grounded", grounded);
    }

    private void JumpPlayer()
    {
        if (gatherInput.jumpInput && grounded)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
        }
        gatherInput.jumpInput = false;
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        grounded = leftCheckHit;
    }

}