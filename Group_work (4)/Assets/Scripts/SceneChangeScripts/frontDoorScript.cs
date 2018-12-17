using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class frontDoorScript : MonoBehaviour {

    public GameObject carKey;
    public GameObject elizabethKey;
    public GameObject picture, phone, gift, note, glass;

    public Color loadToColor = Color.black;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && carKey.GetComponent<KeyDialogTrigger>().haveKey == true && elizabethKey.GetComponent<KeyDialogTrigger>().haveKey == true && picture.GetComponent<DialogTrigger>().havePicture == true && phone.GetComponent<DialogTrigger>().havePhone == true && gift.GetComponent<DialogTrigger>().haveGift == true && note.GetComponent<DialogTrigger>().haveNote == true && glass.GetComponent<DialogTrigger>().haveGlass == true)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Initiate.Fade("Outside", loadToColor, 1.0f);
                //SceneManager.LoadScene("Outside");
            }
        }

    }
}
