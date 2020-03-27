using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnim : MonoBehaviour
{
    public Transform Body;
    public Transform HandRight;
    public Transform HandLeft;
    public Transform FootRight;
    public Transform FootLeft;
    
    [Header("Others")]
    public Transform FootRight2;
    public Transform FootLeft2;

    void Start(){

    }

    void Update(){
        
    }

    [ContextMenu("Setup")]
    void SetupComponet(){
        Body = transform.Find("Body");
        HandRight = transform.Find("Hand1");
        HandLeft = transform.Find("Hand2");
        FootRight = transform.Find("Leg1");
        FootLeft = transform.Find("Leg2");
        FootRight2 = transform.Find("Leg11");
        FootLeft2 = transform.Find("Leg22");
    }
}
