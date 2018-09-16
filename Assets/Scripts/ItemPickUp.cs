using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemPickUp : NetworkBehaviour
{

    private new Rigidbody rigidbody;

    private Transform heldBy;

    private PlayerType heldByType;

    private void Start()
    {

        heldByType = PlayerType.None;

        rigidbody = GetComponent<Rigidbody>();

    }

    public void Update()
    {
        if(heldByType != PlayerType.None)
        {
            gameObject.transform.position = heldBy.position;
            gameObject.transform.rotation = heldBy.rotation;
        }
    }



    public void HeldBy(Transform holding, PlayerType ptype)
    {
        //Can't grab if already help by another player of the same type
        if (ptype != heldByType)
        {
            heldBy = holding;
            heldByType = ptype;
            rigidbody.isKinematic = true;
        }
    }

    /*
    //void OnTriggerEnter(Collider other)
    void OnCollisionEnter(Collision other)
    {
        if (isServer == false)
            return;

        var mouse = other.gameObject.GetComponent<Mouse>();
        var chef = other.gameObject.GetComponent<Chef>();

        if (chef == null && mouse == null)
            return;

        if (mouse != null)
        {
            Debug.Log("mouse picked up item");
        }
        else
        {
            Debug.Log("chef picked up item");
        }

        gameObject.transform.SetParent(other.gameObject.transform);
        gameObject.transform.localPosition = new Vector3(0, 1, -2);

        rigidbody.isKinematic = true;
    }
    */
}
