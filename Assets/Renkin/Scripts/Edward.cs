using System.Collections.Generic;
using UnityEngine;

public class Edward : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand _handType;
    [SerializeField]
    private List<GameObject> _magicCircles;

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
            foreach (var magicCircle in _magicCircles)
            {
                magicCircle.SetActive(true);
            }
        }
    }
}
