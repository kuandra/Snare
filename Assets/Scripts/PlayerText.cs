using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Control))]
public class PlayerText : MonoBehaviour
{
    public TMP_Text Text;
    private Control _snake;

    private void Awake()
    {
        _snake = GetComponent<Control>();
    }

    private void OnEnable()
    {
        _snake.BallUpdat += OnBallUpdat;
    }

    private void OnDisable()
    {
        _snake.BallUpdat -= OnBallUpdat;
    }

    private void OnBallUpdat(int Size)
    {
        Text.text = Size.ToString();
    }
}
