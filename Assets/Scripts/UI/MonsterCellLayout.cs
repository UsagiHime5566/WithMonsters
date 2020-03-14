using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterCellLayout : MonoBehaviour
{
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextNumber;

    [Header("Data")]
    public int Index;
    void Start()
    {
        StartCoroutine(UpdateCell());
    }

    WaitForSeconds waitCell = new WaitForSeconds(1);
    IEnumerator UpdateCell(){
        while(true){
            yield return waitCell;

            TextNumber.text = string.Format("x {0}", GameManager.Instance.Get_MonsterCollect(Index));
        }
    }
}
