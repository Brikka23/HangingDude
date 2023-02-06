using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    private void Start()
    {
        _player.AddForce(Vector3.left * 125, ForceMode2D.Impulse);
    }
}
