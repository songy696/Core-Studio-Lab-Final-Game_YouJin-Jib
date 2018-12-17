using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollowMouse : MonoBehaviour { 

    private Vector3 mousePos;
    public float moveSpeed;
    public GameObject ghost;

	// Use this for initialization
	void Start () {
        moveSpeed = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
        
        //our code for following mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
       transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed);

        //flipping sprite
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float worldXPos = Camera.main.ScreenToWorldPoint(pos).x;

        if (worldXPos > ghost.transform.position.x) 
        {
            // Facing right
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else
        {
            // Facing left
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

    }
}
