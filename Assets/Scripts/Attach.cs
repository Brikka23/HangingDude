using UnityEngine;

public class Attach : InteractionWithRope
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(1))
        {
            AttachToRope(collision);
        }
    }

    private void AttachToRope(Collider2D collision)
    {
        _joint.enabled = true;
        _lastPartOfRope = collision.gameObject.GetComponent<Rigidbody2D>();
        _joint.connectedBody = _lastPartOfRope;
        Swing.PushOfPlayer(Vector3.right);
    }
}
