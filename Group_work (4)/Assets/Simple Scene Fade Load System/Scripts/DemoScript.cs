using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DemoScript : MonoBehaviour {
    //name of the scene you want to load
    
	public Color loadToColor = Color.black;
	
	public void GoFade(string scene)
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }
}
