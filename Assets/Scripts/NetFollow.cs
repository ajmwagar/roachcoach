using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetFollow : NetworkBehaviour {

    public Transform src_head;
    public Transform src_lHand;
    public Transform src_rHand;
    public Transform src_body;

    public Transform head;
    public Transform lHand;
    public Transform rHand;

    public Transform body;

    //private GloveController gloveController;

    private Vector3 bodyRotationMask = new Vector3(0,1,0);

    private bool lHandControllerModelEnabled = true;
    private bool rHandControllerModelEnabled = true;

    // Use this for initialization
    void Start () {
        // GameObject h = GameObject.Find("VRCamera");
        // if(h)
        //     src_head = h.transform;
        // GameObject l = GameObject.Find("Hand1");
        // if (l)
        //     src_lHand = l.transform;
        // GameObject r = GameObject.Find("Hand2");
        // if (r)
        //     src_rHand = r.transform;

        //gloveController = GetComponent<GloveController>();

        //TODO: fix
        if(true)
        //if(GameManager.Instance.playerMode == GameManager.PlayerMode.VR)
        {
            //don't show hat model for vr player
            head.GetChild(0).GetComponent<Renderer>().enabled = false;

            //hook up to VRRig
            StartCoroutine(RetrieveLeftHand());
            StartCoroutine(RetrieveRightHand());
            StartCoroutine(RetrieveHead());
            StartCoroutine(RetrieveBody());
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
		if (hasAuthority && src_head && src_lHand && src_rHand) {
            if (src_head)
            {
                head.position = src_head.position;
                head.rotation = src_head.rotation;
            }

            if (src_lHand)
            {
                lHand.position = src_lHand.position;
                lHand.rotation = src_lHand.rotation;
            }

            if (src_rHand)
            {
                rHand.position = src_rHand.position;
                rHand.rotation = src_rHand.rotation;
            }
			

            //body.position = head.position;
			//body.rotation = Quaternion.Euler(Vector3.Scale(src_body.rotation.eulerAngles,bodyRotationMask));
            //body.localScale = new Vector3(body.localScale.x, body.transform.position.y / 1.5f, body.localScale.z);
		}
    }

    IEnumerator RetrieveLeftHand()
    {
        while(src_lHand == null)
        {
            GameObject l = GameObject.Find("Hand1");
            if (l)
            {
                src_lHand = l.transform;
                //disable built in model for hand
                //l.GetComponentInChildren<Valve.VR.InteractionSystem.SpawnRenderModel>().enabled = false;
                StartCoroutine(HideLHand());

            }
            yield return new WaitForEndOfFrame();
        }

        //gloveController.SetLeftController(src_lHand.GetComponent<Valve.VR.InteractionSystem.Hand>());
    }

    IEnumerator RetrieveRightHand()
    {
        while(src_rHand == null)
        {
            GameObject r = GameObject.Find("Hand2");
            if (r)
            {
                src_rHand = r.transform;
                //disable built in model for hand
                //r.GetComponent<Valve.VR.InteractionSystem.Hand>().controllerPrefab = null;
                //r.GetComponentInChildren<Valve.VR.InteractionSystem.SpawnRenderModel>().enabled = false;
                StartCoroutine(HideRHand());

            }


            yield return new WaitForEndOfFrame();
        }

        //gloveController.SetRightController(src_rHand.GetComponent<Valve.VR.InteractionSystem.Hand>());
    }

    IEnumerator RetrieveHead()
    {
        while(src_head == null)
        {
            GameObject h = GameObject.Find("VRCamera");
            if(h)
                src_head = h.transform;

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RetrieveBody()
    {
        if(body != null)
        {
            while (src_body == null)
            {
                GameObject b = GameObject.Find("BodyCollider");
                if (b)
                    src_body = b.transform;

                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator HideLHand()
    {
        while (lHandControllerModelEnabled)
        {
            if (src_lHand.GetComponentInChildren<Valve.VR.InteractionSystem.SpawnRenderModel>() != null)
            {
                src_lHand.GetComponentInChildren<Valve.VR.InteractionSystem.SpawnRenderModel>().enabled = false;
                lHandControllerModelEnabled = false;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator HideRHand()
    {
        while (rHandControllerModelEnabled)
        {
            if(src_rHand.GetComponentInChildren<Valve.VR.InteractionSystem.SpawnRenderModel>()!= null)
            {
                src_rHand.GetComponentInChildren<Valve.VR.InteractionSystem.SpawnRenderModel>().enabled = false;
                rHandControllerModelEnabled = false; 
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
