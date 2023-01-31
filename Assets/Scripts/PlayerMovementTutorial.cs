using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]

    //dios mio no puedo más no funciona ni con pegamento no salta y todo el rato está en el aire :(
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    public float cantidadGravedad = -20f;
    
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        Physics.gravity = new Vector3(0, cantidadGravedad, 0);
        rb.freezeRotation = true;

        
        ResetJump();
    }

    private void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight + 0.2f, whatIsGround, QueryTriggerInteraction.Ignore);

        Debug.DrawRay(transform.position, Vector3.down * Mathf.Infinity, Color.green);

        MyInput();
        SpeedControl();


        if (grounded)
        {
            ////Debug.Log("toca el suelo");
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}