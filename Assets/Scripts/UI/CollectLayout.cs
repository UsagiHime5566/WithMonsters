using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectLayout : MonoBehaviour
{
    public RectTransform content;
    public MonsterCellLayout cellLayout;
    void Start()
    {
        MonsterPool pool = GameManager.Instance.monsterPool;
        for (int i = 0; i < pool.ListPool.Count; i++)
        {
            MonsterUnit item = pool.ListPool[i];
            MonsterCellLayout newCont = Instantiate(cellLayout, content);
            newCont.InitUI(item, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
