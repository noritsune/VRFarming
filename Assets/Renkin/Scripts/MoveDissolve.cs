using UnityEngine;

public class MoveDissolve : MonoBehaviour
{
    private Material _mat;
    private float _offset = 0;

    void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        _offset += Time.deltaTime;
        _mat.SetFloat("HideOffset", _offset);
    }
}
