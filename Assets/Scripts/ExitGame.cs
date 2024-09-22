using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public void SwitchScene()
    {

#if UNITY_EDITOR
        //½s¿è¾¹
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //¥´¥]
        Application.Quit();
#endif

    }
}

