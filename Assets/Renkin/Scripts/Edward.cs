using System.Collections.Generic;
using UnityEngine;

public class Edward : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand _handType;
    [SerializeField]
    private List<GameObject> _magicCircles;
    [SerializeField]
    private GameObject _magicCircles_onGround;

    private string _anotherHandTag;

    private void Start()
    {
        _anotherHandTag = _handType.Equals(OVRHand.Hand.HandLeft) ? "RightHand" : "LeftHand";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(_anotherHandTag))
        {
            Debug.Log("両手を合わせた！");

            //手の甲に魔法陣を出す
            foreach (var magicCircle in _magicCircles)
            {
                magicCircle.SetActive(true);
            }
        }

        if(other.tag.Equals("Floor"))
        {
            if(!_magicCircles[0].activeSelf) return;

            //地面に魔法陣を出す
            _magicCircles_onGround.SetActive(true);
        }
    }
}
