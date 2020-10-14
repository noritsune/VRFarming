using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CoDestoroyMyself());
    }

    private IEnumerator CoDestoroyMyself()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
