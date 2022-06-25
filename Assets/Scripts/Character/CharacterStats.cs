using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Game/Character/Stats")]

public class CharacterStats : ScriptableObject
{
    [field: SerializeField]
    public int HitPoints { get; set; }
    [field: SerializeField]
    public int Speed { get; set; }
}
