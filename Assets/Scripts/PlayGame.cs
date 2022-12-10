using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button button;
    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;
    [SerializeField] private AudioListener audioListener;

    void Start () {
        button = GetComponent<Button>();
       // button.image.sprite = soundOn;
        AudioListener.pause = false;
    }
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TurnSound()
    {
        if (button.image.sprite == soundOn)
        {
            button.image.sprite = soundOff;
        }
        else
        {
            button.image.sprite = soundOn;
        }
        AudioListener.pause = !AudioListener.pause;
    }
}
