using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFRoomToLastScene : MonoBehaviour {

    public Color loadToColor = Color.black;

    
    void OnTriggerStay2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Initiate.Fade("LastScene", loadToColor, 1.0f);
            }
            }

    }
        }
