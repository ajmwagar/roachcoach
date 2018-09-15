using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveController : MonoBehaviour {
    public Animator LGlove;
    public Animator RGlove;

    private Valve.VR.InteractionSystem.Hand lController;
    private Valve.VR.InteractionSystem.Hand rController;

    //public Animator controller;
	//private bool click = false;

    private bool foundLeft;
    private bool foundRight;

	// Use this for initialization
	void Start () {
        // controller = this.GetComponent<Animator>();

        foundLeft = foundLeft = false;
        // StartCoroutine(RetrieveLeftHand());
        // StartCoroutine(RetrieveRightHand());

    }
	
	// Update is called once per frame
	void Update () {

        if (lController && lController.GetStandardInteractionButtonDown())
        {
            LGlove.SetBool("IsGrabing",true);
        }
        else if(lController && lController.GetStandardInteractionButtonUp())
        {
            LGlove.SetBool("IsGrabing", false);
        }

        if (rController && rController.GetStandardInteractionButtonDown())
        {
            RGlove.GetComponent<Animator>().SetBool("IsGrabing", true);
        }
        else if (rController && rController.GetStandardInteractionButtonUp())
        {
            RGlove.GetComponent<Animator>().SetBool("IsGrabing", false);
        }

        //grab ();
    }

    public void SetLeftController(Valve.VR.InteractionSystem.Hand controller)
    {
        lController = controller;
    }

    public void SetRightController(Valve.VR.InteractionSystem.Hand controller)
    {
        rController = controller;
    }

    /*
	void grab()
	{
        if (Input.GetMouseButtonDown (1)) 
		{
			click = !click;
			controller.SetBool("IsGrabing",click);
		}
	}
    */

    IEnumerator RetrieveLeftHand()
    {
        while (lController == null)
        {
            Transform hand = GetComponent<NetFollow>().src_lHand;
            if (hand)
            {
                GameObject l = hand.gameObject;
                if (l)
                    lController = l.GetComponent<Valve.VR.InteractionSystem.Hand>();

                yield return new WaitForEndOfFrame();
            }
        }

        foundLeft = true;
    }

    IEnumerator RetrieveRightHand()
    {
        while (rController == null)
        {
            Transform hand = GetComponent<NetFollow>().src_rHand;
            if (hand)
            {
                GameObject r = hand.gameObject;
                if (r)
                    rController = r.GetComponent<Valve.VR.InteractionSystem.Hand>();

                yield return new WaitForEndOfFrame();
            }
        }

        foundRight = true;
    }

}
