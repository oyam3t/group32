// Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forjump : MonoBehaviour
{
    public float speed = 5f; // Speed deÄŸiÅŸkenini tanÄ±mlÄ±yoruz ve bir baÅŸlangÄ±Ã§ deÄŸeri veriyoruz.
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
    //    public float speed = 5f; // Speed deðiþkenini tanýmlýyoruz ve bir baþlangýç deðeri veriyoruz.
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
    // Karakterin zÄ±plamasÄ±
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 2D hareket ve animasyon kontrolÃ¼
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1.0f;
            Debug.Log("hÄ±z 1");
        }
        else
        {
            speed = 0.0f;
            Debug.Log("hÄ±z 0");
        }
    }
    /*=======
    //        // Karakterin zýplamasý
    //        if (Input.GetButtonDown("Jump"))
    //        {
    //            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //        }

    //        // 2D hareket ve animasyon kontrolü
    //        if (Input.GetKey(KeyCode.Space))
    //        {
    //            speed = 1.0f;
    //            Debug.Log("hýz 1");
    //        }
    //        else
    //        {
    //            speed = 0.0f;
    //            Debug.Log("hýz 0");
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
            // Renge gÃ¶re hasar verme mantÄ±ÄŸÄ± burada olmalÄ±
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
            // Superboss Ã¶lme mantÄ±ÄŸÄ±
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

            // Renk deÄŸiÅŸtirme kontrolleri
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentSpearColor = SpearColor.Yellow;
                Debug.Log("MÄ±zrak rengi sarÄ±");
                UpdateSpearColor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentSpearColor = SpearColor.Red;
                Debug.Log("MÄ±zrak rengi kÄ±rmÄ±zÄ±");
                UpdateSpearColor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentSpearColor = SpearColor.Blue;
                Debug.Log("MÄ±zrak rengi mavi");
                UpdateSpearColor();
            }

            // Hareket animasyonu kontrolÃ¼
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            bool isWalking = (moveHorizontal != 0 || moveVertical != 0);
            animator.SetBool("isWalking", isWalking);
        }

        void Attack()
        {
            // MÄ±zrak saldÄ±rÄ±sÄ± mantÄ±ÄŸÄ± (Ã¶rn. raycasting ile saldÄ±rÄ±)
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
            {
                if (hit.collider.CompareTag("Superboss"))
                {
                    Superboss superboss = hit.collider.GetComponent<Superboss>();
                    if (superboss != null)
                    {
                        // MÄ±zrak rengine gÃ¶re zarar verme
                        Color spearColor = GetSpearColor();
                        superboss.TakeDamage(spearColor);
                    }
                }
            }

            // SaldÄ±rÄ± animasyonunu tetikleme
            animator.SetTrigger("Attack");
        }

        Color GetSpearColor()
        {
            // Burada karakterin mÄ±zrak rengini belirleme mantÄ±ÄŸÄ±
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
            // MÄ±zrak rengini gÃ¼ncelleme
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
            // Karakterin Ã¶lme mantÄ±ÄŸÄ±
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
//        // Mýzrak saldýrýsý mantýðý (örn. raycasting ile saldýrý)
//        RaycastHit hit;
//        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
//        {
//            if (hit.collider.CompareTag("Superboss"))
//            {
//                Superboss superboss = hit.collider.GetComponent<Superboss>();
//                if (superboss != null)
//                {
//                    // Mýzrak rengine göre zarar verme
//                    Color spearColor = GetSpearColor();
//                    superboss.TakeDamage(spearColor);
//                }
//            }
//        }
//    }

//    Color GetSpearColor()
//    {
//        // Burada karakterin mýzrak rengini belirleme mantýðý
//        // Örn. 1: Sarý, 2: Kýrmýzý, 3: Mavi
//        int colorIndex = 1; // Bu deðeri nasýl belirlerseniz
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
//        // Karakterin ölme mantýðý
//        Debug.Log("Player is dead!");
//    }
//}
>>>>>>> Stashed changes
*/