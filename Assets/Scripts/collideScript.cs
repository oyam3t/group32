using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collideScript : MonoBehaviour
{

    //[SerializeField]
    //GameObject character;
    //[SerializeField]
    //Transform characterTransform;
    int sayac = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("enemy")))
        {
            Destroy(gameObject);// ok düþmana deðdiðinde yok etme
        }
    }




}//class
