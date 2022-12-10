using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesManager : MonoBehaviour
{
    [SerializeField] private int ActiveHolesCount = 4;
    
    [SerializeField] private List<HoleBehaviour> allHoles;
    private List<HoleBehaviour> holesInactive = new List<HoleBehaviour>();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
