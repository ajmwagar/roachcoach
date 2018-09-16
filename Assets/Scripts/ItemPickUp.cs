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

    private Vector3 prevPos;
    private Vector3 curPos;

    private Vector3 curVelocity;

    private Mouse mouse; 

    private void Start()
    {

        heldByType = PlayerType.None;

        rigidbody = GetComponent<Rigidbody>();

        curPos = rigidbody.transform.position;

        curVelocity = Vector3.zero;

        mouse = GetComponent<Mouse>();

    }

    private void FixedUpdate()
    {

        prevPos = curPos;
        curPos = rigidbody.transform.position;

        Vector3 velocity = (curPos - prevPos) / Time.deltaTime;

        curVelocity = (velocity + curVelocity) / 2;
    }

    public void Update()
    {
        if(heldByType != PlayerType.None && heldBy)
        {
            gameObject.transform.position = heldBy.position;
            gameObject.transform.rotation = heldBy.rotation;
        }
    }



    public void HeldBy(Transform holding, PlayerType ptype)
    {
        //Can't grab if already help by another player of the same type
        //Also, mouse can't pick up another mouse
        if (ptype != heldByType && !(mouse && ptype == PlayerType.Mouse) && !(ptype == PlayerType.Mouse && gameObject.CompareTag("Plate")))
        {
            heldBy = holding;
            heldByType = ptype;
            rigidbody.isKinematic = true;
            if (mouse)
            {
                Debug.Log("Mouse Pickup");
                GetComponentInChildren<Basic3DRBmovement>().enabled = false;
            }
        }
    }

    /*
    public void HeldBy(FixedJoint joint, PlayerType ptype)
    {
        //Can't grab if already help by another player of the same type
        if (ptype != heldByType)
        {
            joint.connectedBody = rigidbody;
            heldByType = ptype;
            rigidbody.isKinematic = false;
        }
    }
    */

    public void Drop()
    {
        heldBy = null;
        heldByType = PlayerType.None;
        rigidbody.isKinematic = false;
        rigidbody.velocity = curVelocity;

        if (mouse)
        {
            Debug.Log("Mouse Drop");
            GetComponentInChildren<Basic3DRBmovement>().enabled = true;
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
