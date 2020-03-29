using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UnitAnim : MonoBehaviour , IPointerDownHandler
{
    public Transform Body;
    public Transform HandRight;
    public Transform HandLeft;
    public Transform FootRight;
    public Transform FootLeft;
    public Transform Cry;
    
    [Header("Others")]
    public Transform FootRight2;
    public Transform FootLeft2;

    float horizonJump = 0.05f;
    float rotMax = 30;

    float moveAmount = 0.1f;
    float moveDuration = 0.7f;
    float stretchAmount = 1.1f;

    float lerpParam = 0.1f;

    int hitTimes = 0;
    int maxHitTimes;
    public System.Action OnHitSelf;

    [HideInInspector] public Sequence tweenAnim;

    List<float> bodyAngles = new List<float>(){
        0,
        0,
        0,
        0,
        0,
        0
    };

    void Start(){
        maxHitTimes = Random.Range(3, 8);

        transform.position = new Vector3(-horizonJump/2, 0, 0);
        float targetStretch = transform.localScale.y * stretchAmount;

        // transform.DOMoveX(horizonJump, moveDuration * 2).SetLoops(-1, LoopType.Yoyo).OnStepComplete(()=>{
        //     Instantiate(GameManager.Instance.monsterPool.GetRandomEffect(), transform.position, Quaternion.identity).transform.localScale *= 0.1f;
        // });

        //transform.DOLocalMoveY(moveAmount, moveDuration).SetLoops(-1, LoopType.Yoyo);
        //transform.DOScaleY(targetStretch, moveDuration).SetLoops(-1, LoopType.Yoyo);

        tweenAnim = DOTween.Sequence();
        tweenAnim.Append(transform.DOMoveX(horizonJump, moveDuration * 2).OnStepComplete(()=>{
            Instantiate(GameManager.Instance.monsterPool.GetRandomEffect(), transform.position, Quaternion.identity).transform.localScale *= 0.1f;
        }));
        tweenAnim.Join(transform.DOLocalMoveY(moveAmount, moveDuration).SetLoops(2, LoopType.Yoyo));
        tweenAnim.Join(transform.DOScaleY(targetStretch, moveDuration).SetLoops(2, LoopType.Yoyo));
        tweenAnim.SetLoops(-1, LoopType.Yoyo);

        StartCoroutine(BodyAngle());
    }

    WaitForSeconds wait = new WaitForSeconds(3);
    IEnumerator BodyAngle(){
        while (true)
        {
            for (int i = 0; i < bodyAngles.Count; i++)
            {
                bodyAngles[i] = Random.Range(-rotMax, rotMax);
            }

            yield return wait;
        }
    }

    void Update(){

        HandRight.eulerAngles = Vector3.Lerp(HandRight.eulerAngles, new Vector3(0, 0, bodyAngles[0]), lerpParam);
        HandLeft.eulerAngles = Vector3.Lerp(HandLeft.eulerAngles, new Vector3(0, 0, bodyAngles[1]), lerpParam);
        FootRight.eulerAngles = Vector3.Lerp(FootRight.eulerAngles, new Vector3(0, 0, bodyAngles[2]), lerpParam);
        FootLeft.eulerAngles = Vector3.Lerp(FootLeft.eulerAngles, new Vector3(0, 0, bodyAngles[3]), lerpParam);
        
        if(FootRight2) FootRight2.eulerAngles = Vector3.Lerp(FootRight2.eulerAngles, new Vector3(0, 0, bodyAngles[4]), lerpParam);
        if(FootLeft2) FootLeft2.eulerAngles = Vector3.Lerp(FootLeft2.eulerAngles, new Vector3(0, 0, bodyAngles[5]), lerpParam);


        // HandRight.Rotate(0, 0, Random.Range(randMin, randMax));
        // if(HandRight.eulerAngles.z > rotMax) HandRight.eulerAngles = new Vector3(0, 0, rotMax);
        // if(HandRight.eulerAngles.z < -rotMax) HandRight.eulerAngles = new Vector3(0, 0, -rotMax);

        // HandLeft.Rotate(0, 0, Random.Range(randMin, randMax));
        // if(HandLeft.eulerAngles.z > rotMax) HandLeft.eulerAngles = new Vector3(0, 0, rotMax);
        // if(HandLeft.eulerAngles.z < -rotMax) HandLeft.eulerAngles = new Vector3(0, 0, -rotMax);

        // FootRight.Rotate(0, 0, Random.Range(randMin, randMax));
        // if(FootRight.eulerAngles.z > rotMax) FootRight.eulerAngles = new Vector3(0, 0, rotMax);
        // if(FootRight.eulerAngles.z < -rotMax) FootRight.eulerAngles = new Vector3(0, 0, -rotMax);

        // FootLeft.Rotate(0, 0, Random.Range(randMin, randMax));
        // if(FootLeft.eulerAngles.z > rotMax) FootLeft.eulerAngles = new Vector3(0, 0, rotMax);
        // if(FootLeft.eulerAngles.z < -rotMax) FootLeft.eulerAngles = new Vector3(0, 0, -rotMax);

        // if(FootRight2) FootRight2.Rotate(0, 0, Random.Range(randMin, randMax));
        // if(FootRight2) if(FootRight2.eulerAngles.z > rotMax) FootRight2.eulerAngles = new Vector3(0, 0, rotMax);
        // if(FootRight2) if(FootRight2.eulerAngles.z < -rotMax) FootRight2.eulerAngles = new Vector3(0, 0, -rotMax);
        // if(FootLeft2) FootLeft2.Rotate(0, 0, Random.Range(randMin, randMax));
        // if(FootLeft2) if(FootLeft2.eulerAngles.z > rotMax) FootLeft2.eulerAngles = new Vector3(0, 0, rotMax);
        // if(FootLeft2) if(FootLeft2.eulerAngles.z < -rotMax) FootLeft2.eulerAngles = new Vector3(0, 0, -rotMax);

    }

    public void OnPointerDown(PointerEventData eventData){
        if(hitTimes >= maxHitTimes)
            return;

        hitTimes++;
        OnHitSelf?.Invoke();
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(eventData.position), out hit)) {
            Instantiate(GameManager.Instance.monsterPool.GetRandomHit(), hit.point, Quaternion.identity);
        }

        if(hitTimes < maxHitTimes)
            return;
        if(Cry == null)
            return;
        
        Cry.gameObject.SetActive(true);
    }

    void OnDestroy() {
        if(tweenAnim == null)
            return;
        tweenAnim.Kill();
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(!pauseStatus)
            return;
        if(tweenAnim == null)
            return;

        DestroySelf();
    }

    public void DestroySelf(){
        Destroy(gameObject);

        if(tweenAnim == null)
            return;
        tweenAnim.Kill();
        
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
        Cry = transform.Find("Cry");
        Cry.gameObject.SetActive(false);
    }
}
