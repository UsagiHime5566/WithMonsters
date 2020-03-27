using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTNSound : MonoBehaviour
{
    public UISounds.UISoundList useSound;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate {
            UISounds.instance.PlaySound(useSound);
        });
    }
}
