using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterCellLayout : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextNumber;

    [Header("Data")]
    public MonsterUnit data;
    public int cellIndex;

    public void InitUI(MonsterUnit src, int index){
        data = src;
        Icon.sprite = data.icon;
        cellIndex = index;
        Icon.color = Color.black;

        if(GameManager.Instance.gameConstant.isDebugMode){
            Icon.color = Color.white;
            TextName.text = data.unitName;
        }
    }

    void Start()
    {
        StartCoroutine(UpdateCell());
    }

    WaitForSeconds waitCell = new WaitForSeconds(1);
    IEnumerator UpdateCell(){
        while(true){
            yield return waitCell;

            int currentNum = GameManager.Instance.Get_MonsterCollect(cellIndex);
            if(currentNum > 0) {
                TextNumber.text = string.Format("x {0}", currentNum);
                Icon.color = Color.white;
                TextName.text = data.unitName;
            }
        }
    }
}
