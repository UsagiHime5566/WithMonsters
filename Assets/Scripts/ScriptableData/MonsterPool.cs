using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MonsterPool : ScriptableObject
{
    public List<ExploreSheet> exloreTable;
    public List<float> probabilitys;
    public List<MonsterUnit> ListPool;
    public List<ParticleSystem> jumpEffects;
    public List<ParticleSystem> hitEffects;

    public MonsterUnit GetRandomUnit(int exploreRate){
        
        int maxPool = 0;
        for (int i = exloreTable.Count - 1; i >= 0 ; i--)
        {
            if(GameManager.Instance.Get_Explore() <= exloreTable[i].explore)
                maxPool = exloreTable[i].count;
        }

        float maxProb = 0;
        for (int i = 0; i < maxPool; i++)
        {
            maxProb += ListPool[i].Probability;
        }

        float random = Random.Range(0, maxProb);
        float stack = 0;

        #if UNITY_EDITOR
            //Debug.Log($"Get pool {random} of {maxPool}");
        #endif

        for (int i = 0; i < maxPool; i++)
        {
            stack += ListPool[i].Probability;
            if(random <= stack)
                return ListPool[i];

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

    public ParticleSystem GetRandomHit(){
        return hitEffects[Random.Range(0, hitEffects.Count)];
    }

    [System.Serializable]
    public class ExploreSheet
    {
        public int explore;
        public int count;
    }
}

