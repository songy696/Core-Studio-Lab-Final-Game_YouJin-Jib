using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneDialogTrigger : MonoBehaviour {

    public Dialogue dialogue;


    public void TriggerDialogue()
    {

        FindObjectOfType<DialogManager>().StartDialoque(dialogue);

    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {


            TriggerDialogue();

        }
	
	
	}
}
