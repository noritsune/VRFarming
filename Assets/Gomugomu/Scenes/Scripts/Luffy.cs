using UnityEngine;

[RequireComponent(typeof(OVRSkeleton))]
[RequireComponent(typeof(OVRHand))]
public class Luffy : MonoBehaviour
{
    [SerializeField, Header("秒速")]
    private float _moveSpeed;
    [SerializeField]
    private Transform _tackedTrans;
    [SerializeField]
    private OVRHand.Hand _hand;

    private OVRSkeleton _oVRSkeleton;
    private OVRHand _oVRHand;

    private void Start()
    {
        _oVRSkeleton = GetComponent<OVRSkeleton>();
        _oVRHand = GetComponent<OVRHand>();
    }

    void Update()
    {
        if(!_oVRHand.IsTracked || _oVRHand.HandConfidence.Equals(OVRHand.TrackingConfidence.Low)) return;
        
        Vector3 pos = transform.position;

        float dir = _hand.Equals(OVRHand.Hand.HandLeft) ? 1 : -1;
        if (canExtend())
        {
            pos += _tackedTrans.right * dir * _moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
        else if(canShrink())
        {
            transform.Translate((_tackedTrans.position - pos) * 2 * _moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private bool IsStraight(float threshold, params OVRSkeleton.BoneId[] boneids)
    {
        if (boneids.Length < 3) return false;   //調べようがない
        Vector3? oldVec = null;
        var dot = 1.0f;
        for (var index = 0; index < boneids.Length-1; index++)
        {
            var v = (_oVRSkeleton.Bones[(int)boneids[index+1]].Transform.position - _oVRSkeleton.Bones[(int)boneids[index]].Transform.position).normalized;
            if (oldVec.HasValue)
            {
                dot *= Vector3.Dot(v, oldVec.Value); //内積の値を総乗していく
            }
            oldVec = v;//ひとつ前の指ベクトル
        }
        return dot >= threshold; //指定したBoneIDの内積の総乗が閾値を超えていたら直線とみなす
    }

    private bool canExtend()
    {
        var isIndexStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        var isMiddleStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);
        var isRingStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Ring1, OVRSkeleton.BoneId.Hand_Ring2, OVRSkeleton.BoneId.Hand_Ring3, OVRSkeleton.BoneId.Hand_RingTip);
        var isPinkyStraight = IsStraight(0.27f, OVRSkeleton.BoneId. Hand_Pinky1, OVRSkeleton.BoneId.Hand_Pinky2, OVRSkeleton.BoneId.Hand_Pinky3, OVRSkeleton.BoneId.Hand_PinkyTip);

        return isIndexStraight && !isMiddleStraight && !isRingStraight && !isPinkyStraight;
    }

    private bool canShrink()
    {
        var isThumbStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Thumb1, OVRSkeleton.BoneId.Hand_Thumb2, OVRSkeleton.BoneId.Hand_Thumb3, OVRSkeleton.BoneId.Hand_ThumbTip);
        var isIndexStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Index1, OVRSkeleton.BoneId.Hand_Index2, OVRSkeleton.BoneId.Hand_Index3, OVRSkeleton.BoneId.Hand_IndexTip);
        var isMiddleStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Middle1, OVRSkeleton.BoneId.Hand_Middle2, OVRSkeleton.BoneId.Hand_Middle3, OVRSkeleton.BoneId.Hand_MiddleTip);
        var isRingStraight = IsStraight(0.27f, OVRSkeleton.BoneId.Hand_Ring1, OVRSkeleton.BoneId.Hand_Ring2, OVRSkeleton.BoneId.Hand_Ring3, OVRSkeleton.BoneId.Hand_RingTip);
        var isPinkyStraight = IsStraight(0.27f, OVRSkeleton.BoneId. Hand_Pinky1, OVRSkeleton.BoneId.Hand_Pinky2, OVRSkeleton.BoneId.Hand_Pinky3, OVRSkeleton.BoneId.Hand_PinkyTip);

        return isThumbStraight && !isIndexStraight && !isMiddleStraight && !isRingStraight && !isPinkyStraight;
    }
}
