using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{
    [SerializeField]
    float time = 0.25f;
    [SerializeField]
    float addscore = 10f;
    [SerializeField]
     Rigidbody2D rb2d;
    Vector2 difference = Vector2.zero;
    bool finished = true;
    [SerializeField]
    private GameObject bullet;
    
    private void Start()
    {
        //rb2d = bullet.gameObject.GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.F) && finished == true)
        {
            Time.timeScale = time; // zaman yavaþlatma
            StartCoroutine(skillclock());
            finished = false;
            Debug.Log("ilk saniye");
            StartCoroutine(skillwaitclock());
        }
        
    }//update
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            try {
                rb2d.AddForce(new Vector2(addscore, 0.5f));// oku hýzlandýrma
            } catch {
            
            }
            
        }
    }//fixed update
    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }//on mouse down

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }// on mouse drag
    IEnumerator skillclock()// zamaný 0.8 saniye sonra tekrar kendi haline döndürme
    {
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 1.0f;
    }
    IEnumerator skillwaitclock()//skill kullanabilme için bekletme
    {
        Debug.Log("15 saniye skilli yeniden kullanabilme için beklemeye alýndý");
        yield return new WaitForSeconds(15f);
        finished = true;
        Debug.Log("son saniye");
    }

}//class
