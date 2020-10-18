using UnityEngine;

public class Mustang : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float _threshold;
    [SerializeField]
    private GameObject _fire_base;

    private OVRSkeleton _oVRSkeleton;
    private bool _isMiddleStraight_old = false;

    private void Start()
    {
        _oVRSkeleton = GetComponent<OVRSkeleton>();
    }

    private void Update()
    {
        var isMiddleStraight = IsStraight(_threshold, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);

        if(!isMiddleStraight && _isMiddleStraight_old)
        {
            Instantiate(
                _fire_base, 
                position: _oVRSkeleton.Bones[(int)OVRSkeleton.BoneId.Hand_IndexTip].Transform.position,
                rotation: Quaternion.identity
            );
        }

        _isMiddleStraight_old = isMiddleStraight;
    }

    private bool IsStraight(float threshold, params OVRSkeleton.BoneId[] boneids)
    {
        if (boneids.Length < 3) return false;   //調べようがない
        Vector3? oldVec = null;
        var dot = 1.0f;
        for (var index = 0; index < boneids.Length-1; index++)
        {
            if(index > boneids.Length) continue;

            var v = (_oVRSkeleton.Bones[(int)boneids[index+1]].Transform.position - _oVRSkeleton.Bones[(int)boneids[index]].Transform.position).normalized;
            if (oldVec.HasValue)
            {
                dot *= Vector3.Dot(v, oldVec.Value); //内積の値を総乗していく
            }
            oldVec = v;//ひとつ前の指ベクトル
        }
        return dot >= threshold; //指定したBoneIDの内積の総乗が閾値を超えていたら直線とみなす
    }
}
