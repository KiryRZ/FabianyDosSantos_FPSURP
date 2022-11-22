using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationobject : MonoBehaviour
{
    public float angular_speed = 90;


    public void Update()
    {
        transform.Rotate(Vector3.right * angular_speed * Time.deltaTime);
    }
}
