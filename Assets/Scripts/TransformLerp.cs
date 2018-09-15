using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TransformLerp : NetworkBehaviour {

	[SyncVar]
	Vector3 realPosition;
	[SyncVar]
	Quaternion realRotation;
    [SyncVar]
    float syncDelay;


    private float lastSync;
    private float lastUpdate;

    public float updateInterval = 0.11f;

	private float interp = 0.1f;

	private bool isLerping = true;

    //define target to track, otherise track self
    public Transform target;

    private float lastSynchronizationTime = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    // Use this for initialization
    void Start () {
		GameObject status = GameObject.Find ("GameStatus");
        if (status)
            isLerping = true;
            //isLerping = status.GetComponent<GameMode> ().isLerping;
		if (!isLerping) {
			this.enabled = false;
		}
        lastUpdate = Time.time;

        //if not tracking another gameobject, use self instead
        if (target == null)
        {
            target = transform;
        }
	}

    /*

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {

        Rigidbody rbdy = target.GetComponent<Rigidbody>();

        Vector3 syncPosition = Vector3.zero;
        Vector3 syncVelocity = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = target.position;
            stream.Serialize(ref syncPosition);

            if (rbdy)
            {
                syncVelocity = rbdy.velocity;
            }
            else
            {
                syncVelocity = Vector3.zero;
            }
            
            stream.Serialize(ref syncVelocity);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            stream.Serialize(ref syncVelocity);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = rbdy.position;
        }
    }

    void Update()
    {
        if (isLerping && !hasAuthority)
        {
            SyncedMovement();
        }
    }

    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;
        transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }
    */

    // Update is called once per frame
	void Update () {
		if (isLerping) {
            lastSync = Time.time - lastUpdate;
            //lastUpdate = Time.time;

            if (hasAuthority)
            {
                if (lastSync >= updateInterval)
                {
                    Rigidbody rbdy = target.GetComponent<Rigidbody>();

                    
                    realPosition = target.transform.position;

                    if (rbdy)
                    {
                        //not working right, commenting out for now
                        //realPosition += rbdy.velocity * lastSync;

                        //trying with worldscale component added
                        realPosition += Vector3.Scale(rbdy.velocity * lastSync, rbdy.transform.lossyScale);
                    }

                    realRotation = target.transform.rotation;

                    lastSync = 0.0f;
                    syncDelay = Time.time - lastUpdate;
                    CmdSync(realPosition, realRotation, syncDelay);
                    lastUpdate = Time.time;
                }
            }
            else {
                if(syncDelay > 0)
                {
                    target.transform.position = Vector3.Lerp(target.transform.position, realPosition, Time.deltaTime / syncDelay);
                    target.transform.rotation = Quaternion.Lerp(target.transform.rotation, realRotation, Time.deltaTime / syncDelay);
                }
            }
        }

		
	}

	[Command]
	void CmdSync(Vector3 pos, Quaternion rot,float delay)
    {
		realPosition = pos;
		realRotation = rot;
        syncDelay = delay;
    }
    
}
