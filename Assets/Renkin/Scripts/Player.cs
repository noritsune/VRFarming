using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform _maskTrans;
    [SerializeField]
    private int HP;
    
    private float _damageUnit;
    private float _maskTransScale_def;

    private void Start()
    {
        _maskTransScale_def = _maskTrans.localScale.x;
        _damageUnit = _maskTransScale_def / (float)HP;
    }

    private void Update()
    {
        float _maskTransScale = Mathf.Min(_maskTransScale_def, _maskTrans.localScale.x + _damageUnit * 0.1f * Time.deltaTime);
        _maskTrans.localScale = Vector3.one * _maskTransScale;
    }

	public void OnGetDamege ()
	{
        if(_maskTrans.localScale.x == 0) {
            //TODO: ゲームオーバー処理を入れる
            return;
        }

        _maskTrans.DOScale(Mathf.Max(0, _maskTrans.localScale.x - _damageUnit), 0.5f)
        .SetEase(Ease.InOutBack);
	}
}
