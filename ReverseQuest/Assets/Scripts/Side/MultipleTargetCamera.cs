using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MultipleTargetCamera : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    public List<GameObject> objectToFollow;

    private void Awake()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(objectToFollow.Count > 0)
        {
            VirtualCamera.Follow = objectToFollow[0].transform;
        }        
    }
}
