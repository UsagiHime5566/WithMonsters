using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MonsterPool : ScriptableObject
{
    public List<float> probabilitys;
    public List<MonsterUnit> ListPool;
    public List<ParticleSystem> jumpEffects;

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

    [ContextMenu("Preview Probability")]
    void PreviewProbability(){
        float max = 0;
        foreach (var item in ListPool)
        {
            max += item.Probability;
        }
        probabilitys = new List<float>();
        for (int i = 0; i < ListPool.Count; i++)
        {
            Debug.Log("pro:" + ListPool[i].Probability + "/" + max.ToString());
            float pro = ListPool[i].Probability / max;
            probabilitys.Add(pro * 100);
        }
    }

    public ParticleSystem GetRandomEffect(){
        return jumpEffects[Random.Range(0, jumpEffects.Count)];
    }
}
