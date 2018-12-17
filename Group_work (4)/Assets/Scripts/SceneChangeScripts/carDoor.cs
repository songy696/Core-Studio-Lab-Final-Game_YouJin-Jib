using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carDoor : MonoBehaviour {

    public GameObject gps;

    public Color loadToColor = Color.black;

    public AudioSource carSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && gps.GetComponent<DialogTrigger>().foundGPS == true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (carSound != null)
                {
                    carSound.Play();
                }

                Initiate.Fade("GF_frontDoor", loadToColor, 1.0f);
                //SceneManager.LoadScene("GF_frontDoor");
            }
        }

    }
}
