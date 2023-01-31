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
    public float impactForce = 30f;
    public float rangoDeDisparo = 200;
    public float frecuenciaDisparo = 15f;
    private Transform cameraPlayerTransform;

    public GameObject impactEffect;

    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;


    



    private void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;


    }



    private void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / frecuenciaDisparo;
            //esto significa que por cada frame estoy llamando al shoot
            Shoot();


        }



        }

        void Shoot()
        {
            muzzleFlash.Play(); //esto es el efecto y estoy diciendo que se active, por cada getbutton FIRE1
            RaycastHit hit; //cuando el raycast impacta
            if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, rangoDeDisparo, capasAfectables)) // si los raycast que salen de la posicion de la camera, hacia adelante, a la maxima distancia que el rayopueda alcanzar, el punto donde chocó, y las capas donde afectan
            {
                Target_shoot target = hit.transform.GetComponent<Target_shoot>(); //llamamos al otro script que son para los que se puede destruir, y luego creamos la variable target, y significa que
                //el raycast que golpee que sea target, necesita que el objeto tenga el componente target shoot
                Debug.Log(hit.transform.name);
                if (target != null) // si el target no es null, es decir es falso que sea negativo 
                {
                    //Debug.Log(hit.transform.name);

                    target.TakeDamage(damage); // el target recibe el void de take damage
                }
                if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.3f);
            }


        }
    }
