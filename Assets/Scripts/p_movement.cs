using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_movement : MonoBehaviour
{
    [Header("Movimiento")]
    public float VelocidadCaminar;
    public float groundDrag;
    public float fuerzaSalto = 5;
    public float distanciaSuelo = 0.5f;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();

        if (grounded)
        { 
                rb.drag = groundDrag;
            Debug.Log("salto");
        }
        else
        {
            rb.drag = 0;
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector3.up * fuerzaSalto;
            }
        }
        

    }
  

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * VelocidadCaminar * 10f, ForceMode.Force);
    }

}
