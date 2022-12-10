using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager Instance;

   private void Awake()
   {
      if (Instance != null && Instance != this) 
      { 
         Destroy(this); 
      } 
      else 
      { 
         Instance = this; 
      } 
   }
   
   public AudioSource backgroundMusic;
   public AudioSource extraMusic;
   
   public AudioSource dropSFX;
   public AudioSource hahaSFX;
   public AudioSource deathSFX;
   public AudioSource drillSFX;
   public AudioSource UVLampSFX;
   public AudioSource FillSFX;
   public AudioSource SuckerSFX;
   
   public void PlayBackgroundMusic()
   {
      backgroundMusic.Play();
   }

   public void PlayExtraMusic()
   {
      
      DOTween.To(()=>  extraMusic.volume, x=>  extraMusic.volume = x, 1, 4f);

   }
   
}
