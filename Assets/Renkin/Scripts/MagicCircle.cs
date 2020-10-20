using System.Collections;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private bool _canMove;

    private Transform _parent_def;
    private Vector3 _pos_def;
    private Quaternion _rot_def;

    private void OnEnable()
    {
        StartCoroutine(CoDisableMySelf());

        if(_canMove) return;
        
        _pos_def = transform.localPosition;
        _rot_def = transform.localRotation;
        _parent_def = transform.parent;
        transform.parent = null;
    }

    private IEnumerator CoDisableMySelf()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);

        if(_canMove) yield break;

        transform.parent = _parent_def;
        transform.localPosition = _pos_def;
        transform.localRotation = _rot_def;
    }
}
