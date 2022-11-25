using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask capasAfectables;
    public GameObject agujerobalaPrefab;

    [Header("Parametros del Disparo")]
    public float rangoDeDisparo = 200;
    private Transform cameraPlayerTransform;
    //Agregan punto de inicio de donde la bala saldra.
    public Transform balaInicio;
    //Agregan Bala Prefab
    public GameObject BalaPrefab;
    //Agregar Bala Velocidad
    public float BalaVelocidad;


    private float TimeBala = 10f;
    private float tiempoFrecuenciaDisparo = 0f;


    public float frecuenciaDisparo = 0.5f;



    private void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;


    }



    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > tiempoFrecuenciaDisparo)
            {
            //1-Instanciar la BalaPrefab en las posiciones de BalaInicio
                        GameObject nuevaBala;

                        nuevaBala = Instantiate(BalaPrefab, balaInicio.position, balaInicio.rotation);

                        //Obtener Rigidbody para agregar Fuerza y Agregar la fuerza a la Bala
                        nuevaBala.GetComponent<Rigidbody>().AddForce(balaInicio.right * BalaVelocidad);


                RaycastHit hit;
                if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, rangoDeDisparo, capasAfectables))
                {
                    Destroy(nuevaBala, 1f);
                    GameObject AgujerobalaClone = Instantiate(agujerobalaPrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                    Destroy(AgujerobalaClone, 4f);
                    Debug.Log("Disparo");
                }
                else
                {
                    Destroy(nuevaBala, 2f);
                    }
            }

            
        }


   
}
   
    
}
