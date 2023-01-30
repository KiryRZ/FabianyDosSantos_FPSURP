using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public LayerMask capasAfectables;
    public GameObject agujerobalaPrefab;

    [Header("Parametros del Disparo")]
    public float damage = 10f;
    public float rangoDeDisparo = 200;
    private Transform cameraPlayerTransform;

    public ParticleSystem muzzleFlash;

    ////Agregan punto de inicio de donde la bala saldra.
    //public Transform balaInicio;
    ////Agregan Bala Prefab
    //public GameObject BalaPrefab;
    ////Agregar Bala Velocidad
    //public float BalaVelocidad;


    //private float TimeBala = 10f;
    //private float tiempoFrecuenciaDisparo = 0f;


    //public float frecuenciaDisparo = 0.5f;



    private void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;


    }



    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            muzzleFlash.Play();
            //if (Time.time > tiempoFrecuenciaDisparo)
            {
                //1-Instanciar la BalaPrefab en las posiciones de BalaInicio
                //GameObject nuevaBala;

                //nuevaBala = Instantiate(BalaPrefab, balaInicio.position, balaInicio.rotation);

                //Obtener Rigidbody para agregar Fuerza y Agregar la fuerza a la Bala
                //nuevaBala.GetComponent<Rigidbody>().AddForce(balaInicio.right * BalaVelocidad);


                RaycastHit hit;
                if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, rangoDeDisparo, capasAfectables))
                {
                    Target_shoot Target = hit.transform.GetComponent<Target_shoot>();
                    Debug.Log(hit.transform.name);
                    if (Target != null)
                    {
                        //Debug.Log(hit.transform.name);

                        Target.TakeDamage(damage);
                    }
                    //    Destroy(nuevaBala, 1f);
                    //    GameObject AgujerobalaClone = Instantiate(agujerobalaPrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                    //    Destroy(AgujerobalaClone, 4f);
                    //    Debug.Log("Disparo");
                    //}
                    //else
                    //{
                    //    Destroy(nuevaBala, 2f);
                    //    }
                }


            }



        }


    }
}
