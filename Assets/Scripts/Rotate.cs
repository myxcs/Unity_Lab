using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
 

[SerializeField] private float speed = 1.5f;
   private void Update()
    {
        //rotates the object around itself at a speed of 2 degrees per second}
        transform.Rotate(0,0,360 * speed * Time.deltaTime); 
  }
}