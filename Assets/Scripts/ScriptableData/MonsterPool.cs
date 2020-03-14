using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MonsterPool : ScriptableObject
{
    public List<MonsterUnit> ListPool;

    public MonsterUnit GetRandomUnit(){
        float max = 0;
        foreach (var item in ListPool)
        {
            max += item.Probability;
        }

        float random = Random.Range(0, max);
        float stack = 0;
        foreach (var item in ListPool)
        {
            stack += item.Probability;
            if(random <= stack)
                return item;
        }

        return null;
    }
}
