using UnityEngine;

public class Swing : InteractionWithRope
{
    private void Start()
    {
        PushOfPlayer(Vector3.left);
    }

    public static void PushOfPlayer(Vector3 _vector)
    {
        _player.AddForce(_vector * _pushForce, ForceMode2D.Impulse);
    }

}
