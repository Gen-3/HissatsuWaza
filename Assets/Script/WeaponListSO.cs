using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu]

public class WeaponListSO : ScriptableObject
{
    public List<WeaponSO> weaponSOs;
}
