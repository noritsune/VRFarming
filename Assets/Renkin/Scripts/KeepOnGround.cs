using UnityEngine;

public class KeepOnGround : MonoBehaviour
{
    [SerializeField]
    private float offset_y;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = offset_y;
        transform.position = pos;
        
        transform.rotation = Quaternion.identity;
    }
}
