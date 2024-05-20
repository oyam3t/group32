// Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forjump : MonoBehaviour
{
    public float speed = 5f; // Speed değişkenini tanımlıyoruz ve bir başlangıç değeri veriyoruz.
    public float jumpForce = 10f;
    public Rigidbody2D r2d;
    public Animator animator;
    private Rigidbody rb;
    /*=======
    //using System.Collections;
    //using System.Collections.Generic;
    //using UnityEngine;

    //public class forjump : MonoBehaviour
    //{
    //    public float speed = 5f; // Speed de�i�kenini tan�ml�yoruz ve bir ba�lang�� de�eri veriyoruz.
    //    public float jumpForce = 10f;
    //    public Rigidbody2D r2d;
    //    public Animator animator;
    //    private Rigidbody rb;
    >>>>>>> Stashed changes

    //    void Start()
    //    {
    //        rb = GetComponent<Rigidbody>();
    //        r2d = GetComponent<Rigidbody2D>();
    //        animator = GetComponent<Animator>();
    //    }

        void Update()
        {
    //        // Karakterin ileri geri hareketi (3D hareket)
    //        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    //        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

    //        transform.Translate(new Vector3(moveHorizontal, 0, moveVertical));

    <<<<<<< Updated upstream*/
    // Karakterin zıplaması
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 2D hareket ve animasyon kontrolü
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            Debug.Log("hız 1");
        }
        else
        {
            speed = 0.0f;
            Debug.Log("hız 0");
        }
    }
    /*=======
    //        // Karakterin z�plamas�
    //        if (Input.GetButtonDown("Jump"))
    //        {
    //            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        }

    //        // 2D hareket ve animasyon kontrol�
    //        if (Input.GetKey(KeyCode.Space))
    //        {
    //            speed = 1.0f;
    //            Debug.Log("h�z 1");
    //        }
    //        else
    //        {
    //            speed = 0.0f;
    //            Debug.Log("h�z 0");
    //        }
    >>>>>>> Stashed changes

    //        animator.SetFloat("speed", speed);
    //        r2d.velocity = new Vector2(speed, r2d.velocity.y);
    //    }
    //}

    <<<<<<< Updated upstream*/
    public class Superboss : MonoBehaviour
    {
        public int health = 100;

        public void TakeDamage(Color damageColor)
        {
            // Renge göre hasar verme mantığı burada olmalı
            if (damageColor == Color.yellow)
            {
                health -= 10;
            }
            else if (damageColor == Color.red)
            {
                health -= 20;
            }
            else if (damageColor == Color.blue)
            {
                health -= 30;
            }

            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            // Superboss ölme mantığı
            Debug.Log("Superboss is dead!");
            Destroy(gameObject);
        }
    }

    public class Player : MonoBehaviour
    {
        public int health = 100;
        private Animator animator;
        public Renderer spearRenderer;

        private enum SpearColor
        {
            Yellow,
            Red,
            Blue
        }

        private SpearColor currentSpearColor = SpearColor.Yellow;

        void Start()
        {
            animator = GetComponent<Animator>();
            // Assuming the spear is a child object with a Renderer component
            spearRenderer = transform.Find("Spear").GetComponent<Renderer>();
            UpdateSpearColor();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }

            // Renk değiştirme kontrolleri
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentSpearColor = SpearColor.Yellow;
                Debug.Log("Mızrak rengi sarı");
                UpdateSpearColor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentSpearColor = SpearColor.Red;
                Debug.Log("Mızrak rengi kırmızı");
                UpdateSpearColor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentSpearColor = SpearColor.Blue;
                Debug.Log("Mızrak rengi mavi");
                UpdateSpearColor();
            }

            // Hareket animasyonu kontrolü
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            bool isWalking = (moveHorizontal != 0 || moveVertical != 0);
            animator.SetBool("isWalking", isWalking);
        }

        void Attack()
        {
            // Mızrak saldırısı mantığı (örn. raycasting ile saldırı)
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                if (hit.collider.CompareTag("Superboss"))
                {
                    Superboss superboss = hit.collider.GetComponent<Superboss>();
                    if (superboss != null)
                    {
                        // Mızrak rengine göre zarar verme
                        Color spearColor = GetSpearColor();
                        superboss.TakeDamage(spearColor);
                    }
                }
            }

            // Saldırı animasyonunu tetikleme
            animator.SetTrigger("Attack");
        }

        Color GetSpearColor()
        {
            // Burada karakterin mızrak rengini belirleme mantığı
            switch (currentSpearColor)
            {
                case SpearColor.Yellow: return Color.yellow;
                case SpearColor.Red: return Color.red;
                case SpearColor.Blue: return Color.blue;
                default: return Color.white;
            }
        }

        void UpdateSpearColor()
        {
            // Mızrak rengini güncelleme
            Color color = GetSpearColor();
            spearRenderer.material.color = color;
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
            // Karakterin ölme mantığı
            Debug.Log("Player is dead!");
        }
    }
}
/*=======
//public class Player : MonoBehaviour
//{
//    public int health = 100;

//    void Update()
//    {
//        if (Input.GetButtonDown("Fire1"))
//        {
//            Attack();
//        }
//    }

//    void Attack()
//    {
//        // M�zrak sald�r�s� mant��� (�rn. raycasting ile sald�r�)
//        RaycastHit hit;
//        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
//        {
//            if (hit.collider.CompareTag("Superboss"))
//            {
//                Superboss superboss = hit.collider.GetComponent<Superboss>();
//                if (superboss != null)
//                {
//                    // M�zrak rengine g�re zarar verme
//                    Color spearColor = GetSpearColor();
//                    superboss.TakeDamage(spearColor);
//                }
//            }
//        }
//    }

//    Color GetSpearColor()
//    {
//        // Burada karakterin m�zrak rengini belirleme mant���
//        // �rn. 1: Sar�, 2: K�rm�z�, 3: Mavi
//        int colorIndex = 1; // Bu de�eri nas�l belirlerseniz
//        switch (colorIndex)
//        {
//            case 1: return Color.yellow;
//            case 2: return Color.red;
//            case 3: return Color.blue;
//            default: return Color.white;
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        health -= damage;
//        if (health <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        // Karakterin �lme mant���
//        Debug.Log("Player is dead!");
//    }
//}
>>>>>>> Stashed changes
*/