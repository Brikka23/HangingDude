using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Slide : MonoBehaviour
{
    private const float ShellRadius = 0.01f;
    private const float MinMoveDistance = 0.001f;

    private readonly RaycastHit2D[] _hitBuffer = new RaycastHit2D[16];
    private readonly List<RaycastHit2D> _hitBufferList = new List<RaycastHit2D>(16);

    [SerializeField] private float _minGroundNormalY = 0.65f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rb2d;
    private bool _grounded;

    private Vector2 _velocity;
    private Vector2 _groundNormal;
    private Vector2 _targetVelocity;
    private ContactFilter2D _contactFilter;

    private void OnEnable()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        SetVelocity();
        _grounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 move = GetMovementSide(deltaPosition);

        Movement(move, false);
        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }

    private void SetVelocity()
    {
        _targetVelocity = _groundNormal * _speed;

        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = _targetVelocity.x; ;
    }

    private void Jump() {
        _velocity += Vector2.up * _jumpForce;
    }

    private void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = _rb2d.Cast(move, _contactFilter, _hitBuffer, distance + ShellRadius);

            _hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                _hitBufferList.Add(_hitBuffer[i]);
            }

            for (int i = 0; i < _hitBufferList.Count; i++)
            {
                Vector2 currentNormal = _hitBufferList[i].normal;
                if (currentNormal.y > _minGroundNormalY)
                {
                    _grounded = true;
                    if (yMovement)
                    {
                        _groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);
                if (projection < 0)
                {
                    _velocity -= projection * currentNormal;
                }

                float modifiedDistance = _hitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        _rb2d.position += move.normalized * distance;
    }

    private Vector2 GetMovementSide(Vector2 deltaPosition)
    {
        Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);

        return moveAlongGround * deltaPosition.x;
    }

}
