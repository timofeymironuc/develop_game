using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // скорость передвижения
    public float jumpForce = 10f; // сила прыжка

    private Rigidbody2D rb; // компонент Rigidbody2D
    private bool isGrounded = false; // флаг нахождения на земле

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // передвижение влево и вправо
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // проверка нахождения на земле
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // прыжок при нажатии на пробел
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}