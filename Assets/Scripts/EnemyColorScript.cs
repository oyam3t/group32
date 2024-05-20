using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorScript : MonoBehaviour
{

    [SerializeField] Material blue;
    [SerializeField] Material red;
    [SerializeField] Material yellow;
    int number;
    void Start()
    {
        number = (int)Random.Range(1f, 4f);
    }

    
    void Update()
    {
        if (number == 1)
        {
            //normal= blue;
            this.gameObject.GetComponent<Renderer>().material = blue;
        }
        if (number == 2)
        {
            this.gameObject.GetComponent<Renderer>().material = red;
        }
        if (number == 3)
        {
            this.gameObject.GetComponent<Renderer>().material = yellow;
        }
    }
}//class
