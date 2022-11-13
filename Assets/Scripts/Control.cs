
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Control : MonoBehaviour
{
    public List<Transform> Tails;
    public float Distance;
    public GameObject Ball;
    public GameObject BallPrefab;
    public Player player;
    public Game Game;
    public AudioSource SoudFood;

    public float Speed;
    public float speedSnake;

    private Transform _transform;

    public event UnityAction<int> BallUpdat;

    private void Awake()
    {
        BallUpdat?.Invoke(Tails.Count);
    }

    private void OnEnable()
    {
        player.BlockCollider += OnBlockCollidrr;
    }

    private void OnDisable()
    {
        player.BlockCollider -= OnBlockCollidrr;
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

     void FixedUpdate()
    {
        MoveSnake(_transform.position + _transform.forward * speedSnake * Time.fixedDeltaTime);


        float hor = Input.GetAxisRaw("Horizontal");
         Vector3 dir = new Vector3(hor, 0, 0);
       _transform.Translate(dir.normalized*Time.deltaTime*Speed);

        BallUpdat?.Invoke(Tails.Count);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = Distance * Distance;
        Vector3 lastBall = _transform.position;

        foreach (var ball in Tails)
        {
            if((ball.position - lastBall).sqrMagnitude > sqrDistance)
            {
                var temp = ball.position;
                ball.position = lastBall;
                lastBall = temp;
            }
            else
            { 
                break;
            }
        }

        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Food")
        {
            Destroy(collision.gameObject);

            var Ball = Instantiate(BallPrefab);
            Tails.Add(Ball.transform);

            SoudFood.Play();
        }              
    }
   
    private void OnBlockCollidrr()
    {
        Transform deletedBall = Tails[Tails.Count - 1];
        Tails.Remove(deletedBall);
        Destroy(deletedBall.gameObject);

        if (Tails.Count > 0)
            return;
        else
        {
            speedSnake = 0;

            Debug.Log("Game over!");
        }

        BallUpdat?.Invoke(Tails.Count);
    }

   

}

