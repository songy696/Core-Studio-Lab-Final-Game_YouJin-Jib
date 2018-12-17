using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public bool havePicture, havePhone, haveGift, haveNote, haveGlass;

    public bool foundGPS;

    public GameObject car, message;

    public BoxCollider2D carDoor;

    public PolygonCollider2D cheater;

    public AudioSource PickupSound;

    public UnityEvent OnSeeCheater;

    public bool isYesButtonThere;

    public UnityEvent OnSeeCorpse;

    void Start()
    {
        havePicture = false;
        havePhone = false;
        haveGift = false;
        haveNote = false;
        haveGlass = false;

        foundGPS = false;
        carDoor = car.GetComponent<BoxCollider2D>();
        carDoor.enabled = false;
        cheater = message.GetComponent<PolygonCollider2D>();
        cheater.enabled = true;

        isYesButtonThere = false;
    }

    public void TriggerDialogue(){
       
            FindObjectOfType<DialogManager>().StartDialoque(dialogue);
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
       

        if (other.CompareTag("Player"))
        {

         
                if (Input.GetKeyDown(KeyCode.I))
                {
                   
                    TriggerDialogue();
                isYesButtonThere = true;

                if (PickupSound != null)
                {
                    PickupSound.Play();
                }



                if (this.gameObject.CompareTag("Picture"))


                {

                    havePicture = true;

                }

                if (this.gameObject.CompareTag("Phone"))


                {

                    havePhone = true;

                }
                if (this.gameObject.CompareTag("Gift"))


                {

                    haveGift = true;

                }
                if (this.gameObject.CompareTag("Note"))


                {

                    haveNote = true;

                }
                if (this.gameObject.CompareTag("Glass"))


                {

                    haveGlass = true;

                }
                if (this.gameObject.CompareTag("GPS"))


                {

                    foundGPS = true;

                    if (foundGPS)
                    {
                        carDoor.enabled = true;
                        cheater.enabled = false;
                       
                    }

                    OnSeeCheater.Invoke();

                }

                if (this.gameObject.CompareTag("corpse"))
                {
                    OnSeeCorpse.Invoke();
                }


            }

        }

    }
}
