using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_pressing : MonoBehaviour {

    SpriteRenderer rend;

    bool isShowing;
    bool inHidingZone;

    public GameObject enemy;
    public GameObject enemy2;

    // Use this for initialization
    void Start () {
        //rend = this.gameObject.transform.GetChild(0).gameObject;
        rend = GetComponent<SpriteRenderer>();
   
        isShowing = true;
    }
	
	// Update is called once per frame
	void Update () {
        

        //if (!isShowing){
        if(Input.GetKeyDown(KeyCode.H)){
            if (inHidingZone){
                //isShowing = false;
                isShowing = !isShowing;
                rend.enabled = isShowing;
                
            }
            //else {
            //    isShowing = true;
                
            //    rend.enabled = isShowing;
            //}

            
            enemy.GetComponent<enemyScript>().playerShowing = isShowing;
            enemy2.GetComponent<enemyScript>().playerShowing = isShowing;
          
          }
        
   
    }

    void OnTriggerStay2D(Collider2D other) {


        if (other.CompareTag("hidingSpot"))
        {
            Debug.Log("in hiding zone");
            inHidingZone = true;
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    //hide
            //    Debug.Log("hiding");

            //    isShowing = false;
            //    //rend.SetActive(isShowing);
            //    rend.enabled = false;
            //    //gameObject.SetActive(false);

            //    //rend.enabled = !rend.enabled;

            //}
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
