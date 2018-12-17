using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedroomDoor : MonoBehaviour {

    public GameObject bedroomKey;

    public Color loadToColor = Color.black;


    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && bedroomKey.GetComponent<KeyDialogTrigger>().haveKey == true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Initiate.Fade("LivingRoom", loadToColor, 1.0f);
                //SceneManager.LoadScene("LivingRoom");
            }
        }

    }
}
