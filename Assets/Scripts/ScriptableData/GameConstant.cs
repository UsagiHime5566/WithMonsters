using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameConstant : ScriptableObject
{
    [Header("Game Constant")]
    public int MaxMonster = 20;
    public float StaminaExploreCost = 12;
    public float StaminaRecover = 0.1f;

    [Header("Default Player Constant")]
    public float DefaultStaminaMax = 12;
    public int DefaultGold = 99999;

    [Header("Plus Constant")]
    public float EachStaminaPlus = 1f;
    public float EachStaminaRecover = 0.1f;
}
