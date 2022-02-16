using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMovement : MonoBehaviour
{
    private Animator animator;


    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        animator = GetComponent<Animator>();
        
        animator.SetFloat("Speed", 0);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        if(movementDirection != Vector3.zero){
            animator.SetFloat("Speed",movementDirection.magnitude);
        }

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);   

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            

        } 
    }
    

    
}
