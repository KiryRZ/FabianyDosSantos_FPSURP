 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_script_new : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Transform fpsPuntilla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           
            }
        }
    void Shoot ()

     {
                RaycastHit hit;
                if (Physics.Raycast(fpsPuntilla.transform.position, fpsPuntilla.transform.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name);
                }
    }
}
