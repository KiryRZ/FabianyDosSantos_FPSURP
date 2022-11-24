using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_movement : MonoBehaviour
{
    [Header("Movimiento")]
    public float Velocidad;
    public float groundDrag;

    [Header("GroundCheck")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public float fuerzaSalto = 500;

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
        Debug.Log("Suelo");
            if (Input.GetButtonDown("Jump")) rb.AddForce(new Vector3(0, fuerzaSalto, 0));
            rb.drag = groundDrag;
            
        }
        else
        {
            rb.drag = 0;
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

        rb.AddForce(moveDirection.normalized * Velocidad * 10f, ForceMode.Force);
    }
}
