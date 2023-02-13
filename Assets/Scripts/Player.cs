using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float _forcePush;

    private SpriteRenderer _renderer;
    private HingeJoint2D _joint;
    private Rigidbody2D _lastPartOfRope;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _joint = GetComponent<HingeJoint2D>();
        _player.AddForce(Vector3.left * _forcePush, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _joint.connectedBody!=null)
        {
            _joint.connectedBody = null;
            _joint.enabled = false;
        }
        changeColorPlayer();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(1))
        {
            _joint.enabled = true;
            _lastPartOfRope = collision.gameObject.GetComponent<Rigidbody2D>();
            _joint.connectedBody = _lastPartOfRope;
            _player.AddForce(Vector3.right * _forcePush, ForceMode2D.Impulse);
        }
    }

    private void changeColorPlayer()
    {
        _renderer.color = Color.Lerp(Color.red, Color.green, Mathf.Sin(Time.timeSinceLevelLoad));
    }


}
