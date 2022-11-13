using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public Vector2Int destroyRange; 
    private int _destroy;
    private int _attack;
    public int attackText => _destroy - _attack;
    public event UnityAction<int> AtttackUpdat;

    private void Start()
    {
        _destroy = Random.Range(destroyRange.x, destroyRange.y);
        AtttackUpdat?.Invoke(attackText);
    }

    public void Attack()
    {
        _attack++;
        AtttackUpdat?.Invoke(attackText);

        if (_attack == _destroy)
        {
            Destroy(gameObject);
        }
    }
}
