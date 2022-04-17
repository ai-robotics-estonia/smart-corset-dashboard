using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    //public ButtonHandler _button;

    //void Start()
    //{
    //    _button.onClick.AddListener(TaskOnClick);
    //}

    public void handleSignInTap()
    {
        Debug.Log("hit");
        SceneManager.LoadScene("HomeScreenScene");
    }
}
