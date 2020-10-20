using System.Collections.Generic;
using UnityEngine;

public class Edward : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand _handType;
    [SerializeField]
    private List<GameObject> _magicCirclesOnHands;
    [SerializeField]
    private GameObject _magicCircle_onGround;
    [SerializeField]
    private Transform _magicCircle_onGround_generateTrans;

    private string _anotherHandTag;

    private void Start()
    {
        _anotherHandTag = _handType.Equals(OVRHand.Hand.HandLeft) ? "RightHand" : "LeftHand";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(_anotherHandTag))
        {
            //手の甲に魔法陣を出す
            foreach (var magicCircleOnHands in _magicCirclesOnHands)
            {
                magicCircleOnHands.SetActive(true);
            }
        }
        else if(other.tag.Equals("Floor"))
        {
            if(!_magicCirclesOnHands[0].activeSelf) return;

            //地面に魔法陣を出す
            Instantiate(
                _magicCircle_onGround,
                _magicCircle_onGround_generateTrans.position,
                _magicCircle_onGround_generateTrans.rotation
            );

            foreach (var magicCircleOnHands in _magicCirclesOnHands)
            {
                magicCircleOnHands.SetActive(false);
            }
        }
    }
}
