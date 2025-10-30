using UnityEngine;

public class Flipper : MonoBehaviour
{
    public bool IsFacingRight { get; private set; } = true;

    public void FlipToDirection(float horizontalInput)
    {
        if (horizontalInput > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && IsFacingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
