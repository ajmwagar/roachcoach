using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class PoolManager : MonoBehaviour
{

  public GameObject poolObject;
  private ObjectPool objectPool;
  GameObject currentObj ;

  private float startTime;

  // Use this for initialization
  void Start()
  {
    GameObject copy = Instantiate<GameObject>(poolObject, new Vector3(0, 0, 0), Quaternion.identity);
    GameObject copy2 = Instantiate<GameObject>(poolObject, new Vector3(0, 0, 0), Quaternion.identity);
    GameObject copy3 = Instantiate<GameObject>(poolObject, new Vector3(0, 0, 0), Quaternion.identity);
    objectPool = new ObjectPool();
    objectPool.add(copy);
    objectPool.add(copy2);
    objectPool.add(copy3);
    objectPool.disableAll();
    startTime = Time.time;
  
  }

  // Update is called once per frame
  void Update()
  {
    if ((Time.time - startTime) > 1)
    {
      Debug.Log("in time"); ;

      if (currentObj != null)
      {
        currentObj.SetActive(false);
      }
      currentObj = objectPool.next(new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)), Quaternion.identity);
      startTime = Time.time;
    }
  }

  public void resetTime()
  {
    startTime = Time.time;
  }
}
