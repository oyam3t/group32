using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collideScript : MonoBehaviour
{

   
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("son")))
        {
            SceneManager.LoadScene("Polatcan");
        }
    }

   

}//class
