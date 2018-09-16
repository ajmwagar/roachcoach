using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseItemGrabber : MonoBehaviour
{

    public Transform attachPoint;
    PlayerType playerType = PlayerType.Mouse;

    public ItemPickUp holding;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (holding)
            {
                holding.Drop();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    //void OnCollisionEnter(Collision other)
    {

        ItemPickUp item = other.GetComponent<ItemPickUp>();
        if (item)
        {
            item.HeldBy(attachPoint, playerType);
            holding = item;
        }


    }
}
