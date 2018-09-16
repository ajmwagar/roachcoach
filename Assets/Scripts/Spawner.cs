using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using System;
public class Spawner : MonoBehaviour
{
      public Ingredient.ITypes type;
      public GameObject obj;
      public event Action<GameObject, Ingredient.ITypes> onbuttonpress;
      private AudioSource source;
      
      public void Start()
  {
      var netManager = GameObject.FindObjectOfType<NetManager>();
      netManager.RegisterPrefab(obj);
      source = GetComponent<AudioSource>();
    }
  void OnTriggerEnter(Collider col)
  {
       source.Play();
       onbuttonpress.Invoke(obj, type);
  }
}
