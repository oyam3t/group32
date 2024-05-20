using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forjump : MonoBehaviour
{
    public float speed = 5f; // Speed de�i�kenini tan�ml�yoruz ve bir ba�lang�� de�eri veriyoruz.
    public float jumpForce = 10f;
    public Rigidbody2D r2d;
    public Animator animator;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Karakterin ileri geri hareketi (3D hareket)
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveHorizontal, 0, moveVertical));

        // Karakterin z�plamas�
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 2D hareket ve animasyon kontrol�
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            Debug.Log("h�z 1");
        }
        else
        {
            speed = 0.0f;
            Debug.Log("h�z 0");
        }

        animator.SetFloat("speed", speed);
        r2d.velocity = new Vector2(speed, r2d.velocity.y);
    }
}

public class Player : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        // M�zrak sald�r�s� mant��� (�rn. raycasting ile sald�r�)
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if (hit.collider.CompareTag("Superboss"))
            {
                Superboss superboss = hit.collider.GetComponent<Superboss>();
                if (superboss != null)
                {
                    // M�zrak rengine g�re zarar verme
                    Color spearColor = GetSpearColor();
                    superboss.TakeDamage(spearColor);
                }
            }
        }
    }

    Color GetSpearColor()
    {
        // Burada karakterin m�zrak rengini belirleme mant���
        // �rn. 1: Sar�, 2: K�rm�z�, 3: Mavi
        int colorIndex = 1; // Bu de�eri nas�l belirlerseniz
        switch (colorIndex)
        {
            case 1: return Color.yellow;
            case 2: return Color.red;
            case 3: return Color.blue;
            default: return Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Karakterin �lme mant���
        Debug.Log("Player is dead!");
    }
}
