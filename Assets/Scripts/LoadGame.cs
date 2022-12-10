using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public InputAction loadGame;

    private void Start()
    {
        loadGame.Enable();
    }

    private void Update()
    {
        if (loadGame.triggered)
        {
            SceneManager.LoadScene(1);
        }
    }
}
