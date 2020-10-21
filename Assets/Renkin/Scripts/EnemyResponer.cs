using System.Collections;
using UnityEngine;

public class EnemyResponer : MonoBehaviour
{
    [SerializeField]
    private float _responeSeconds;

    public void Respone(GameObject obj)
    {
        StartCoroutine(CoRespone(obj));
    }

    private IEnumerator CoRespone(GameObject obj)
    {
        yield return new WaitForSeconds(_responeSeconds);

        obj.SetActive(true);
    }
}
