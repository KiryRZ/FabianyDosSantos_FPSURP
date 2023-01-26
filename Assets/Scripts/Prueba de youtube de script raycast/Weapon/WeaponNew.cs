using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNew : MonoBehaviour
{
    public int bulletsPerReload = 30;
    public int bulletsLeft;

    public Transform shootPoint;

    public float fireRate = 0.1f;
    float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;
        Debug.Log("Disparu uwu");
        RaycastHit hit;
        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "encontrado!");
        }
    }
}
