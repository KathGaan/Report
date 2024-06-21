using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public void StartButton()
    {
        SoundManager.Instance.ButtonSound();

        Debug.Log("SceneLoad");
    }

    public void SettingButton()
    {
        SettingManager.Instance.OpenOption();
    }

    public void QuitButton()
    {
        SoundManager.Instance.ButtonSound();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
