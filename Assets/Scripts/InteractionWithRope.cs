using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(HingeJoint2D))]
public class InteractionWithRope : MonoBehaviour
{

    protected static Rigidbody2D _player;
    protected static float _pushForce = 125f;
    protected HingeJoint2D _joint;
    protected Rigidbody2D _lastPartOfRope;

    private void Awake()
    {
        _player = GetComponent<Rigidbody2D>();
        _joint = GetComponent<HingeJoint2D>();
    }
}
