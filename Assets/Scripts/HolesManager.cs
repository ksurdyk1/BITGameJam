using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HolesManager : MonoBehaviour
{
    [SerializeField] private int ActiveHolesCount = 4;
    
    [SerializeField] private List<HoleBehaviour> allHoles;
    private List<HoleBehaviour> holesInactive = new List<HoleBehaviour>();

    public Fader fade;
    void Start()
    {
        for (int i = 0; i < allHoles.Count; i++)
        {
            allHoles[i].gameObject.SetActive(false);
            holesInactive.Add(allHoles[i]);
        }
        
        for (int i = 0; i < ActiveHolesCount; i++)
        {
            var rngPointer = Random.Range(0, holesInactive.Count);
            holesInactive[rngPointer].gameObject.SetActive(true);
            holesInactive.RemoveAt(rngPointer);
        }

        foreach (HoleBehaviour hole in holesInactive)
        {
            allHoles.Remove(hole);
        }

        foreach (var hole in allHoles)
        {
            hole.BeginSpawning();
            Debug.Log(hole.holeState);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isEnd = true;
        foreach (HoleBehaviour hole in allHoles)
        {
            if (hole.holeState != HoleState.Healthy)
            {
                isEnd = false;
            }
        }

        if (isEnd)
        {
            SoundManager.Instance.hahaSFX.Play();
            fade.MakeFadeOut(2);
        }
    }
}
