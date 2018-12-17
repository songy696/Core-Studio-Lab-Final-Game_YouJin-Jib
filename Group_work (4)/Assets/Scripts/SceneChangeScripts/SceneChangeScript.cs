﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeScript : MonoBehaviour {

    public string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(scene);
        }

        if (other.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }
}
