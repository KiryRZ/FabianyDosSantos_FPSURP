using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientacion_gira : MonoBehaviour
{

    [SerializeField]
    public Transform camara;

    private Vector3 direccion;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector3(camara.transform.position.x, 0, camara.transform.position.z);
        transform.rotation = Quaternion.
    }
}
