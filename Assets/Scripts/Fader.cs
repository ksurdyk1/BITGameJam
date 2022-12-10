using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeFadeIn()
    {
        this.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().DOFade(1, 0);

        if(    GetComponent<SpriteRenderer>() !=null)
        {
            GetComponent<SpriteRenderer>().DOFade(0, 3f);
           // this.gameObject.SetActive(false);

        }
        else if (GetComponent<RawImage>() != null)
        {
            GetComponent<RawImage>().DOFade(0, 3f);

           // this.gameObject.SetActive(false);
        }
    }
    public void MakeFadeOut(int sceneToFade)
    {
        this.gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().DOFade(1, 3f).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneToFade);
        });
    }
}
