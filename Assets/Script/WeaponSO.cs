using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu]

public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public int weight;
    public int zangekiATK;
    public int sitotsuATK;
    public int dagekiATK;
    public int kaenATK;
    public int raigekiATK;
    public int maryokuATK;
}
