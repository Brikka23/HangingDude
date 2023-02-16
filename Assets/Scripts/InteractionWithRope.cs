using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(HingeJoint2D))]
public class InteractionWithRope : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float _pushForce;

    private HingeJoint2D _joint;
    private Rigidbody2D _lastPartOfRope;

    private void Start()
    {
        _joint = GetComponent<HingeJoint2D>();
        PushPlayer(Vector3.right);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DetachFromRope();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(1))
        {
            AttachToRope(collision);
        }
    }

    private void DetachFromRope()
    {
        _joint.connectedBody = null;
        _joint.enabled = false;
    }

    private void AttachToRope(Collider2D collision)
    {
        _joint.enabled = true;
        _lastPartOfRope = collision.gameObject.GetComponent<Rigidbody2D>();
        _joint.connectedBody = _lastPartOfRope;
        PushPlayer(Vector3.left);
    }


    private void PushPlayer(Vector3 _vector)
    {
        _player.AddForce(_vector * _pushForce, ForceMode2D.Impulse);
    }

}
