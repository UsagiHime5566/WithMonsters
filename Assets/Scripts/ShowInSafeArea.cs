using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInSafeArea : MonoBehaviour
{
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Rect r = Screen.safeArea;

        Debug.LogFormat ("New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}",
                name, r.x, r.y, r.width, r.height, Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
