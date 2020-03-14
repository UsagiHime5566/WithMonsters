using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLayout : MonoBehaviour
{
    public Button BTNSLAM;
    public RectTransform unitPool;
    public RectTransform prefabDummy;
    public RectTransform current;

    private void Start() {
        BTNSLAM.onClick.AddListener(OnSLAM);
    }

    void OnSLAM(){
        if(!GameManager.Instance.CheckStamina())
            return;

        Debug.Log("Create Monster");

        if(current)
            Destroy(current.gameObject);

        MonsterUnit getUnit = GameManager.Instance.monsterPool.GetRandomUnit();

        current = Instantiate(prefabDummy, unitPool);
        current.GetComponent<Image>().sprite = getUnit.icon;

        GameManager.Instance.CostStamina();

        GameManager.Instance.AddMonsterCatch(GameManager.Instance.monsterPool.ListPool.FindIndex(x => x == getUnit));
    }
}
