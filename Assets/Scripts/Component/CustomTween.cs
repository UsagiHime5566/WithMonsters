using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CustomTween : MonoBehaviour
{
    public List<DOTweenAnimation> EnterTweens;
    public List<DOTweenAnimation> ExitTweens;

    public void RunEnterTween(){
        //DOTween.Play ("YOUR_ID_HERE");
        foreach (var item in EnterTweens)
        {
            item.DORestart();
        }
    }

    public void RunExitTween(){
        foreach (var item in ExitTweens)
        {
            item.DORestart();
        }
    }
}
