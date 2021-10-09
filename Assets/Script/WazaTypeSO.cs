using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu]

public class WazaTypeSO : ScriptableObject
{
    public string wazaTypeName;
    public int zangekiRate;
    public int sitotsuRate;
    public int dagekiRate;
    public int kaenRate;
    public int raigekiRate;
    public int maryokuRate;

}
