using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemLayout : MonoBehaviour
{
    public Button BTNExit;
    void Start()
    {
        BTNExit.onClick.AddListener(QuitGame);
    }

    void QuitGame(){
        Application.Quit();
    }
}
