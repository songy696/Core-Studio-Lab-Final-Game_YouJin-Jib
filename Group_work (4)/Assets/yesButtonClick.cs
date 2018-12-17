using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yesButtonClick : MonoBehaviour {
    public Color loadToColor = Color.black;

    public void loadScene(string sceneName)
    {
        Initiate.Fade(sceneName, loadToColor, 1.0f);
    }
}
