using System.Collections;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;

    private void Start()
    {
        StartCoroutine(CoDestoroyMyself());
    }

    private IEnumerator CoDestoroyMyself()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
