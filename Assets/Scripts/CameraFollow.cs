using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private float cameraAbove = 5.0f;
    [SerializeField] private float cameraBehind = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = player.transform.position;
        pos.y = cameraAbove;
        pos.z = player.transform.position.z - cameraBehind;
        transform.position = pos;
        transform.forward = player.transform.position - transform.position;

    }
}
