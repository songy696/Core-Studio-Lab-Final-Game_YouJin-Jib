using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {
    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
       {
            isMouseDown = false;
           lastMousePosition = Vector3.zero;
        }
       


    }

    void OnTriggerStay2D(Collider2D other)
    {
        
        if (isMouseDown)
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                this.transform.position += offset / 3;
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}