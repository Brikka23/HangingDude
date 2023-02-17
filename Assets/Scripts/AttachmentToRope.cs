using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(HingeJoint2D),typeof(OscillationOfPlayer))]
public class AttachmentToRope : MonoBehaviour
{
    private HingeJoint2D _joint;
    private Rigidbody2D _lastPartOfRope;
    private OscillationOfPlayer _swingOfPlayer;

    private void Awake()
    {
        _joint = GetComponent<HingeJoint2D>();
        _swingOfPlayer = gameObject.GetComponent<OscillationOfPlayer>();
    }

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
        _swingOfPlayer.PushOfPlayer(Vector3.right);
    }
}
