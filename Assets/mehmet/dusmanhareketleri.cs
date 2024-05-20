using UnityEngine;

public class dusmanhareketleri : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 5f;

    private bool moveRight = true;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.x - initialPosition.x) > moveDistance)
        {
            FlipCharacterDirection();
        }
    }

    private void FlipCharacterDirection()
    {
        moveRight = !moveRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
