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

  public void Start()
  {
    var netManager = GameObject.FindObjectOfType<NetManager>();
    netManager.RegisterPrefab(obj);
  }
  void OnTriggerEnter(Collider col)
  {
    onbuttonpress.Invoke(obj, type);
  }
}
