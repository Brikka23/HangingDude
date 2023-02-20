using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OscillationOfPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbodyOfPlayer;
    [SerializeField] private float _startPushForce;
    private float _pushForce;

    private void Start()
    {
        _pushForce = _startPushForce;
        PushOfPlayer(Vector3.left);
        _pushForce = _startPushForce /  2.0f;
    }

    public void PushOfPlayer(Vector3 _vector)
    {
        _rigidbodyOfPlayer.AddForce(_vector * _pushForce, ForceMode2D.Impulse);
    }

}
