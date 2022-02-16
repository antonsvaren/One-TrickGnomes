using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayCharacters : MonoBehaviour
{
    Animator animator;

    int isRunningHash;

    Playercontroller playercontroller;

    Vector2 currentMovement;
    bool movementPressed;
    
    void Awake()
    {
        
        playercontroller = new Playercontroller();

        playercontroller.MovementAction.Movement.performed += ctx => 
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = (currentMovement.x != 0 || currentMovement.y != 0);
        };
        playercontroller.MovementAction.Movement.canceled += ctx => currentMovement = Vector2.zero;
        
        

    }
    void Start()
    {
        animator = GetComponent<Animator>();

        isRunningHash = Animator.StringToHash("isRunning");
    }

    
    void Update()
    {
        handleMovement();
        handleRotation();
    }
    void handleMovement()
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if (movementPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if (!movementPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void handleRotation()
    {
        Vector3 currentPosition = transform.position;

        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);

        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }
    void OnEnable()
    {
        playercontroller.MovementAction.Enable();
    }

    void OnDisable()
    {
        playercontroller.MovementAction.Disable();
    }
}
