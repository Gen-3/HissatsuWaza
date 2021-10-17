using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextGenerator : MonoBehaviour
{
    //使用していない？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？
    [SerializeField]
    private GameObject uICanvus;
    [SerializeField]
    private GameObject damageText;
    [SerializeField]
    private GameObject TargetPosition;
    [SerializeField]
    private Vector3 adjustPosition;

    public void ViewDamage(int _damage)
    {
        GameObject _damageObj = Instantiate(damageText, uICanvus.transform);
        _damageObj.GetComponent<Text>().text = _damage.ToString();
        _damageObj.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, TargetPosition.transform.position + adjustPosition);
    }

}