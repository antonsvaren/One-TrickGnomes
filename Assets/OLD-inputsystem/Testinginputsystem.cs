using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Testinginputsystem : MonoBehaviour
{

    private Rigidbody wizard_01;
    private PlayerInput playerInput;
    public float distToGround = 1f;
    private Playercontroller playercontroller;
    private Animator animator;
    Vector2 rotate;

    [SerializeField] private float speed;

    private void Awake()
    {
        wizard_01 = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();

        playercontroller = new Playercontroller();
        playercontroller.MovementAction.Enable();
        playercontroller.MovementAction.Jump.performed += Jump;
        playercontroller.MovementAction.Movement.performed += Movement_performed;
        playercontroller.MovementAction.Rotate.performed += Rotate_performed;

        playercontroller.MovementAction.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        playercontroller.MovementAction.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        
    }

    private void Rotate_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);

    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        
        Vector2 inputVector = playercontroller.MovementAction.Movement.ReadValue<Vector2>();
        wizard_01.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
        if(speed > 0)
        {
            animator.SetFloat("Speed", 1f);
        }
        
    }

   
    
    private void Idle()
    {
        animator.SetFloat("Speed", 0f);
    }

    private void AnimationF()
    {

    }
    
    private void Rotate()
    {

        Vector2 inputVector = new Vector2(0, rotate.x) * 1000f * Time.deltaTime;
        wizard_01.transform.Rotate(inputVector, Space.World);
    }



    public void Jump(InputAction.CallbackContext context)
    {
        if (GroundCheck())
        {
            wizard_01.AddForce(Vector3.up * 2f, ForceMode.Impulse);
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
