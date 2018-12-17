using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesGoToBedRoom : MonoBehaviour {


    public GameObject highheel;
    public GameObject yesButton;

    // Use this for initialization
    void Start()
    {
        yesButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (highheel.GetComponent<DialogTrigger>().isYesButtonThere == true)
        {
            yesButton.SetActive(true);
        }
    }
}
