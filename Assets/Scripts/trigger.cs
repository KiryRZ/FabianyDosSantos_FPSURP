using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    float xrotation;
    float yrotation;
    float zrotation;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("huevos con aceite");
            transform.Rotate(xrotation, yrotation, zrotation);
        }
    }
}
