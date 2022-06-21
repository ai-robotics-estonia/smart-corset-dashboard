using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void changeSceneTo(string scene)
    {
        Debug.Log("hit");
        SceneManager.LoadScene(scene);
    }
}
