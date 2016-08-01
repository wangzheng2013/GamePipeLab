using UnityEngine;
using System.Collections;
using Leap.Unity;

public class ItemController : MonoBehaviour {

    public PinchDetector PinchDetectorL;
    public PinchDetector PinchDetectorR;

    public bool isPinch = true;
    private float startcontroltime;
    private float lastcontroltime;

    private Transform Anchor;
    private Vector3 MyVelocity;
    Rigidbody AnchorBody;
    private float startPinchTime;

    // Use this for initialization
    void Start () {
        GameObject pinchControl = new GameObject("RTS Anchor");
        AnchorBody = pinchControl.AddComponent<Rigidbody>();
        //AnchorBody.useGravity = false;
        //pinchControl.GetComponent<Rigidbody>().isKinematic = true;
        AnchorBody.drag = 0.5f;
        AnchorBody.angularDrag = 0.5f;
        
        Anchor = pinchControl.transform;
        Anchor.transform.parent = transform.parent;
        transform.parent = Anchor;

        startcontroltime = Time.time;
        lastcontroltime = 3;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isPinch)
            return;

        bool didUpdate = false;
        if (PinchDetectorL != null)
            didUpdate |= PinchDetectorL.DidChangeFromLastFrame;
        if (PinchDetectorR != null)
            didUpdate |= PinchDetectorR.DidChangeFromLastFrame;

        if (didUpdate)
        {
            transform.SetParent(null, true);
        }

        if(PinchDetectorL != null && PinchDetectorL.DidStartPinch)
        {
            startPinchTime = Time.time;
        }

        if( PinchDetectorL != null && PinchDetectorL.IsPinching && PinchDetectorR != null && PinchDetectorR.IsPinching)
        {
            //CreateBox();
        }
        else if (PinchDetectorL != null && PinchDetectorL.IsPinching)
        {
            MoveBySingleHand(PinchDetectorL);
        }
        else if(PinchDetectorR != null && PinchDetectorR.IsPinching)
        {
            MoveBySingleHand(PinchDetectorR);
        }

        if(PinchDetectorL != null && PinchDetectorL.DidEndPinch)
        {
            ThrowItem(PinchDetectorL);
        }

        if (didUpdate)
        {
            transform.SetParent(Anchor, true);
        }

        if (isPinch && Time.time > startcontroltime + lastcontroltime)
        {
            isPinch = false;
        }
    }
    
    private void MoveBySingleHand(PinchDetector SingleHand)
    {
        //transform.position = SingleHand.Position;
        Anchor.position = SingleHand.Position;
        //transform.rotation = SingleHand.Rotation;
        Anchor.rotation = SingleHand.Rotation;
        transform.localScale = Vector3.one;
    }
    
    private void ThrowItem(PinchDetector SingleHand)
    {
        float LastTime = Time.time - startPinchTime;
        //Debug.Log("LastTime:" + LastTime);
        AnchorBody.velocity += -SingleHand.transform.forward * Mathf.Min(LastTime,3)*5;
    }
}
