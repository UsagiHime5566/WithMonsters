using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MonsterUnit : ScriptableObject
{
    public Sprite icon;
    public GameObject Unit3D;
    public string unitName;
    public int Probability;
    public int gold;
}
