using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Testinginputsystem : MonoBehaviour
{

    private Rigidbody kenny;
    private PlayerInput playerInput;
    public float distToGround = 1f;
    private Playercontroller playercontroller;
    

    private void Awake()
    {
        kenny = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playercontroller = new Playercontroller();
        playercontroller.MovementAction.Enable();
        playercontroller.MovementAction.Jump.performed += Jump;
        playercontroller.MovementAction.Movement.performed += Movement_performed;
        
        
        
        
    }
    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        
    }
    private void FixedUpdate()
    {
        Vector2 inputVector = playercontroller.MovementAction.Movement.ReadValue<Vector2>();
        float speed = 5f;
        kenny.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (GroundCheck())
        {
            kenny.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            Debug.Log("Jump!" + context.phase);
        }      
        
    }
    public bool isGrounded = false;

    public bool GroundCheck()
    {
        
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            //Debug.Log("Grounded");
            return isGrounded = true;
        }

        else
        {
            //Debug.Log("Not grounded");
            return isGrounded = false;
        }
            
            
    }
}
