using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets
{
  class ObjectPool
  {

    private List<GameObject> objs = new List<GameObject>();
    int currentIndex = 0;

    //Add to pool
    public Boolean add(GameObject obj)
    {
      if (!objs.Contains(obj))
      {
        objs.Add(obj);
        return true;
      }
      return false;
    }

    public void addBulk(GameObject obj, int count)
    {
      for(int i = 0; i < count; i++)
      {
        if (!objs.Contains(obj))
        {
          objs.Add(GameObject.Instantiate<GameObject>(obj, new Vector3(0, 0, 0), Quaternion.identity));
        }
      }
    }


    /// <summary>
    /// Deletes from object pool. Does NOT disable upon deletion.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>    
    public Boolean remove(GameObject obj)
    {
        return objs.Remove(obj);
    }

    public void removeAll()
    {
      foreach (GameObject obj in objs)
      {
        obj.SetActive(false);
      }
    }

    /// <summary>
    /// Gets next object and enables it
    /// </summary>
    /// <returns></returns>
    public GameObject next(Vector3 position, Quaternion rotation)
    {
      if (objs != null && objs.Count > 0)
      {
        currentIndex++;
        currentIndex = currentIndex % objs.Count;
        GameObject obj = objs[currentIndex];
        obj.SetActive(true);
        obj.transform.SetPositionAndRotation(position, rotation);
        return obj;
      }
      else
        return null;
    }

    //disable all
    public void disableAll()
    {
      foreach(GameObject obj in objs)
      {
        obj.SetActive(false);
      }
    }


  }
}
