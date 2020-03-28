using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
using UnityEngine.Android;
#endif

public class RequirePermissions : MonoBehaviour
{
    public static RequirePermissions instance;

    public Action OnNoPermission;

    void Awake() {
        instance = this;
    }

    public void SendRequire()
    {
        #if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera)) {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.Camera);
        }
        #endif

        StartCoroutine(AndroidRequire());
        StartCoroutine(IOSRequire());
    }

    WaitForSeconds wait = new WaitForSeconds(5);
    IEnumerator AndroidRequire(){
        for (int i = 0; i < 10; i++)
        {   
            #if UNITY_2018_3_OR_NEWER && UNITY_ANDROID
            if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.Camera)){
                OnNoPermission?.Invoke();
            }
            #endif

            yield return wait;
        }
    }

    IEnumerator IOSRequire(){
        yield return null;
        #if UNITY_IOS
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            OnNoPermission?.Invoke();
        }
        #endif
    }
}
