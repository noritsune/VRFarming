using UnityEngine;

public class CheckGrabbing : MonoBehaviour
{
    [HideInInspector] public Collider touchingCol = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CanGrab")
        {
            touchingCol = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CanGrab")
        {
            touchingCol = null;
        }
    }
}
