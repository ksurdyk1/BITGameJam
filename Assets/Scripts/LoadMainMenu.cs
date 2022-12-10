using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    public InputAction loadMenu;

    private void Start()
    {
        loadMenu.Enable();
    }

    private void Update()
    {
        if (loadMenu.triggered)
        {
            SceneManager.LoadScene(0);
        }
    }
}
