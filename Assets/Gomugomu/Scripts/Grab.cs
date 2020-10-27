using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private CheckGrabbing[] checkGrabbings = new CheckGrabbing[5];

    public bool IsGrabbing
    {
        get { return m_isGrabbing; }
        set
        {
            m_isGrabbing = value;
        }
    }
    private bool m_isGrabbing = false;

    public Collider GrabbingCol
    {
        get { return m_grabbingCol; }
        set
        {
            m_grabbingCol = value;
        }
    }
    private Collider m_grabbingCol;

    private int grabingFinger = 0;//親指と一緒に何かを掴んでいる指の番号

    private void FixedUpdate()
    {
        if (!IsGrabbing && checkGrabbings[0].touchingCol != null)//掴むきっかけは親指が何かに触れていること
        {
            for (int i = 1; i < 5; i++)
            {
                if (checkGrabbings[i].touchingCol == checkGrabbings[0].touchingCol)//親指以外の指で親指と同じものに触れていればそれは掴んでいるよね
                {
                    grabingFinger = i;
                    IsGrabbing = true;
                    GrabbingCol = checkGrabbings[0].touchingCol;
                    GrabbingCol.gameObject.transform.parent = transform;

                    Rigidbody grabbingRig = GrabbingCol.GetComponent<Rigidbody>();
                    if (grabbingRig)
                    {
                        grabbingRig.isKinematic = true;
                        grabbingRig.constraints = RigidbodyConstraints.None;
                    }

                    break;
                }
            }
        }
        else
        {
            if (checkGrabbings[grabingFinger].touchingCol == null && GrabbingCol)//離すきっかけは親指同じものに触れていた指がものから離れること
            {
                grabingFinger = 0;
                IsGrabbing = false;
                GrabbingCol.transform.parent = null;
                if (GrabbingCol.GetComponent<Rigidbody>() != null) GrabbingCol.GetComponent<Rigidbody>().isKinematic = false;
                GrabbingCol = null;
            }
        }
    }
}