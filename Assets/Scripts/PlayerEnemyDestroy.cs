using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEnemyDestroy : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            
            SceneManager.LoadScene(0);
            
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }



}//class
