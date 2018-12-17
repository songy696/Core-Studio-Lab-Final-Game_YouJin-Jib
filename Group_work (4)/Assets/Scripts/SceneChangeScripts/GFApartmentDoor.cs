using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GFApartmentDoor : MonoBehaviour {

    public Color loadToColor = Color.black;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Initiate.Fade("GF_Room", loadToColor, 1.0f);
                //SceneManager.LoadScene("GF_Room");
            }
        }

    }
}
