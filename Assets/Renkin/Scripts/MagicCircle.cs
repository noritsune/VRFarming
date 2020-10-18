using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(CoDisableMySelf());
    }

    private IEnumerator CoDisableMySelf()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
}
