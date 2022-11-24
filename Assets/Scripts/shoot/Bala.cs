using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoDeVida = 3;

    void Awake()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
       
    }
}
