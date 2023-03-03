using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;
    private uint _quantityOfLifePlayer = 3;

    public void Init(Root init)
    {
        _init = init;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _quantityOfLifePlayer--;
            if(_quantityOfLifePlayer == 0)
            {
                _init.DisableShip();
            }
        }
    }
}
