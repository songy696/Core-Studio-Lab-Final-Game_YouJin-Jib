using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingLight : MonoBehaviour {

    Light ghostLight;

    bool isShowing;
    bool inHidingZone;

    public GameObject enemy;
  

    // Use this for initialization
    void Start () {
        ghostLight = GetComponent<Light>();
        isShowing = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (inHidingZone)
            {
                //isShowing = false;
                isShowing = !isShowing;
                ghostLight.enabled = isShowing;
                
            }
            //else
            //{
            //    isShowing = true;
            //    ghostLight.enabled = isShowing;
            //}

           
            enemy.GetComponent<enemyScript>().playerShowing = isShowing;
            
        }
        

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("hidingSpot"))
        {
            Debug.Log("in hiding zone");
            inHidingZone = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("hidingSpot"))
        {
            inHidingZone = false;
        }
    }
}

