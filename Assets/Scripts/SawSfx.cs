using System;
using UnityEngine;

public class SawSfx : MonoBehaviour
{
   private AudioSource Sfxsource;
   private void Start()
   {
      Sfxsource = GetComponent<AudioSource>();
      Sfxsource.Stop();
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Sfxsource.Play();
      }
   }
   
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Sfxsource.Stop();
      }
   }
   
   
}
