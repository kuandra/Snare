using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Game Game;
    

    public event UnityAction BlockCollider;
    public AudioSource SoundPlay;
    public AudioSource SounDie;
   

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 newPosition)
    {
        Rigidbody.MovePosition(newPosition);
        SoundPlay.Play();
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Block block))
        {
            BlockCollider?.Invoke();
            block.Attack();
        }
    }
    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        
        //MoveSnake = Vector3.zero;
    }

    public void Die()
    {
       Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;

        SounDie.Play();
    }
}
