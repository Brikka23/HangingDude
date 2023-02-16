using UnityEngine;

public class Detach : InteractionWithRope
{
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
