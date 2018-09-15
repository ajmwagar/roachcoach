using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefItemGrabber : MonoBehaviour
{

    public Transform attachPoint;
    PlayerType playerType = PlayerType.Chef;

    private void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    //void OnCollisionEnter(Collision other)
    {

        ItemPickUp item = other.GetComponent<ItemPickUp>();
        if (item)
        {
            item.HeldBy(attachPoint, playerType);
        }


    }
}
