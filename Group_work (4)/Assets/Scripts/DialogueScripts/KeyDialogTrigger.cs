using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyDialogTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    SpriteRenderer obtainedItem;

    CircleCollider2D circlecol;

    public bool haveKey;

    public GameObject hiddenItem;

    public bool canInspect;

    public AudioSource PickupSound;

    public UnityEvent OnPickupKey;


    void Start()
    {
        haveKey = false;
        obtainedItem = GetComponent<SpriteRenderer>();
        circlecol = GetComponent<CircleCollider2D>();

        canInspect = false;

    }

    void Update()
    {

        if (hiddenItem.GetComponent<isItemBehind>().isBehind == true)
        {
            canInspect = false;
            
        }

        if (hiddenItem.GetComponent<isItemBehind>().isBehind == false)
        {
            canInspect = true;
           
            
        }

       

    }

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogManager>().StartDialoque(dialogue);

    }

    void OnTriggerStay2D(Collider2D other)
    {


        if(canInspect)
        {
            //Debug.Log("seeing key");

            if (other.CompareTag("Player"))
            {

                if (Input.GetKeyDown(KeyCode.I))
                {

                    
                    //inspect
                    //textbox will come up

                    TriggerDialogue();
                    

                   if (this.gameObject.CompareTag("key"))

                       
                    {

                        this.obtainedItem.enabled = false;
                         this.circlecol.enabled = false;

                        haveKey = true;
                        Debug.Log("Play!");
                        //SFX
                        if (PickupSound != null)
                        {
                            PickupSound.Play();
                        }

                        //Trigger Event
                        OnPickupKey.Invoke();

                    }


                }

            }
        }
      

    }  
}


