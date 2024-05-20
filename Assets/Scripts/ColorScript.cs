using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorScript : MonoBehaviour
{

    [SerializeField] Material blue;
    [SerializeField] Material red;
    [SerializeField] Material yellow;

    private void Start()
    {
      // normal =  this.gameObject.GetComponent<Material>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
             //normal= blue;
           this.gameObject.GetComponent<Renderer>().material = blue;
        }
        if (Input.GetKey(KeyCode.B))
        {
            this.gameObject.GetComponent<Renderer>().material = red;
        }
        if (Input.GetKey(KeyCode.N))
        {
            this.gameObject.GetComponent<Renderer>().material = yellow;
        }

    }// update
}//class
