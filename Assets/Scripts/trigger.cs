using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject Cuboposicion;
    //float xposition;
    //float yposition;
    //float zposition;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("posición 1");
            Cuboposicion.transform.position = new Vector3(0, 0, transform.position.z - 0.5f) ;
        }
    }
}
