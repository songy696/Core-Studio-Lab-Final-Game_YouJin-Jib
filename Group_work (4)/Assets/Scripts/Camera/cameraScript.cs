using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
   
    public GameObject ghostBoi;
    public float moveSpeed;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
   

	// Use this for initialization
	void Start () {
        moveSpeed = 0.70f;
        bounds = true;
	}
	
	// Update is called once per frame
	void Update () {
       
        transform.position = new Vector3(ghostBoi.transform.position.x, 0, -8) * moveSpeed;

        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z)); 
        }
    }
}
