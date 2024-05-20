using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyScript : MonoBehaviour
{

    
    Color gun;
    Color enemy;
    static int sayac = 0;
     public Vector3 instant;
    [SerializeField] GameObject move;
    [SerializeField] GameObject character;
  
    public void Update()
    {
        Debug.Log(move.transform.position.x);
        instant.x = move.transform.position.x;
        instant.y = move.transform.position.y;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("hello");
            gun = character.gameObject.GetComponent<Renderer>().material.color;
            enemy = collision.gameObject.GetComponent<Renderer>().material.color;
           
            if ( gun == enemy)
            {
                sayac++;
                Instantiate(gameObject, instant, Quaternion.Euler(new Vector3(0f, 0f, -90f)));
                Destroy(gameObject);
                StartCoroutine(time(2f));
                

                Debug.Log("sayac" + sayac);
                // clone.instantiat();
                if (sayac == 3)
                {
                    Destroy(collision.gameObject);
                    sayac = 0;
                }

            }
            else
            {
                Instantiate(gameObject, instant, Quaternion.Euler(new Vector3(0f, 0f, -90f)));
                Destroy(gameObject);
                StartCoroutine(time(2f));
            }
           
        }
    }

    IEnumerator time(float timerr)
    {

        
        yield return new WaitForSeconds(timerr);
       
        
    }




}//class
