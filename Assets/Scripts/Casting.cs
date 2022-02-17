using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour {


    public GameObject fireball;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private int power = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");
        
        
        
    
        GameObject sp;
        Rigidbody body;
        Vector3 direction = GetComponent<Movement>().direction.normalized;
        Vector3 spawnLocation = transform.position + direction.normalized * 2.5f  + Vector3.up * 0.2f;
            
        if (Input.GetButtonDown("Fire2")) {
            sp = Instantiate(fireball, spawnLocation, Quaternion.identity);
            body = sp.GetComponent<Rigidbody>();
            
            // body = sp.AddComponent(typeof(Rigidbody)) as Rigidbody;
            // sp.AddComponent(typeof(PhysicMaterial)) as PhysicMaterial;
            body.AddRelativeForce(direction * power, ForceMode.VelocityChange);
            body.AddRelativeForce(Vector3.up * -4, ForceMode.VelocityChange);
            

        }
    }




}
