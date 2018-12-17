using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isItemBehind : MonoBehaviour {

    public bool isBehind;
    //public GameObject Key;
   
    
    // Use this for initialization
    void Start () {
      isBehind = true;
      //Key.SetActive(false);
   
    
    }
	
	// Update is called once per frame
	void Update () {
        if (isBehind)
        {
            //Debug.Log("Im behind");
        }
        else
        {
            //Debug.Log("Im showing");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("dragging"))
            {
                //Key.SetActive(false);
                isBehind = true;

            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("dragging"))
        {
            //Key.SetActive(true);
            isBehind = false;

        }
    }
}
