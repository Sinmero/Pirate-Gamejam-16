using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : Living
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtCam;



    public override void OnDeath()
    {
        // _cinemachineVirtCam.Follow = transform.parent;
        base.OnDeath();
    }
}
