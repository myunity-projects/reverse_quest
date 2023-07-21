using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    ItemDropToTheSideScreen ItemDropToTheSideScreen;

    public float speed = 3;

    private void Start()
    {
        ItemDropToTheSideScreen = FindAnyObjectByType<ItemDropToTheSideScreen>();
        GlobalVars.canMove = false;
    }

    private void Update()
    {
        if (GlobalVars.canMove)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
