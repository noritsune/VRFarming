using UnityEngine;

public class PosRotSyncher : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTrans;
    [SerializeField]
    private bool synch_pos_x;
    [SerializeField]
    private bool synch_pos_y;
    [SerializeField]
    private bool synch_pos_z;
    [SerializeField]
    private bool synch_rot_x;
    [SerializeField]
    private bool synch_rot_y;
    [SerializeField]
    private bool synch_rot_z;

    void Update()
    {
        Vector3 pos = transform.position;
        if(synch_pos_x) pos.x = _targetTrans.position.x;
        if(synch_pos_y) pos.y = _targetTrans.position.y;
        if(synch_pos_z) pos.z = _targetTrans.position.z;
        transform.position = pos;

        Vector3 rot = transform.rotation.eulerAngles;
        if(synch_rot_x) rot.x = _targetTrans.rotation.eulerAngles.x;
        if(synch_rot_y) rot.y = _targetTrans.rotation.eulerAngles.y;
        if(synch_rot_z) rot.z = _targetTrans.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(rot);
    }
}
