using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingletonManager<InputManager>
{
    public Action keyDownAction;

    private void Update()
    {
        if (Time.timeScale <= 0f) return;

        if (Input.anyKeyDown)
        {
            if (keyDownAction != null)
            {
                keyDownAction.Invoke();
            }
        }
    }
}
