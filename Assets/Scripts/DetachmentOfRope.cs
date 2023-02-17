using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class DetachmentOfRope: MonoBehaviour
{

    private HingeJoint2D _joint;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetachFromRope();
        }
    }

    private void DetachFromRope()
    {
        _joint.connectedBody = null;
        _joint.enabled = false;
    }
}
