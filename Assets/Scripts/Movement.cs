using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    private Rigidbody rigidBody;
    private Vector3 translation;
    private bool jumpPressed;
    private float horizontalInput;
    private float verticalInput;
    public Vector3 direction;
    private bool isMoving;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float jumpingHeight;
        
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Animator animator = GetComponent<Animator>();
        
        if (Input.GetButtonDown("Jump")) {
            jumpPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // Debug.Log(verticalInput);
        if (verticalInput != 0 || horizontalInput != 0) {
            // Debug.Log("inne");
            isMoving = true; 
            direction = new Vector3(horizontalInput, 0, verticalInput);
            animator.SetFloat("Speed", direction.magnitude);


        }
        else {
            isMoving = false;
            animator.SetFloat("Speed", 0);
        }
        
        
        if (Input.inputString != "") Debug.Log(Input.inputString);

        Debug.Log(animator.speed);

    }

    private void FixedUpdate() {
        if (jumpPressed) {
            rigidBody.AddForce(Vector3.up * jumpingHeight, ForceMode.VelocityChange);
            jumpPressed = false;
        }

        if (isMoving) {
            rigidBody.velocity = new Vector3(
                direction.x * movingSpeed,
                rigidBody.velocity.y,
                direction.z * movingSpeed
            );

            rigidBody.transform.forward = direction;
        }


    }
}
