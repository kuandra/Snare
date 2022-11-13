using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTrans;

    private void Update()
    {
        transform.position = PlayerTrans.position;
    }

       
}
