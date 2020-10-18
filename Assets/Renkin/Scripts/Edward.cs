using UnityEngine;

public class Edward : MonoBehaviour
{
    [SerializeField]
    private OVRHand.Hand _handType;

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
        }
    }
}
