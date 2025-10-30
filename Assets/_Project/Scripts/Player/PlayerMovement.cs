using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string JumpButtonName = "Jump";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private JumpChecker _jumpChecker;

    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    public float GetHorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }

    private void Move()
    {
        float horizontMovement = GetHorizontalInput() * _speed;

        Rigidbody2D.linearVelocity = new Vector2(horizontMovement, Rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown(JumpButtonName) && _jumpChecker.CanJump)
        {
            Rigidbody2D.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
        }
    }
}
