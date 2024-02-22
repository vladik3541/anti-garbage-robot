using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    [SerializeField] private float shakeIntensity = 1.0f;
    [SerializeField] private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin m_MultiChannelPerlin;

    private void OnEnable()
    {
        DronHealth.OnDestroyDron += ShakeCamera;
        Bomb.OnDestroyBomb += ShakeCamera;
        TrashHealth.OnCollision += ShakeCamera;
    }
    private void OnDisable()
    {
        DronHealth.OnDestroyDron -= ShakeCamera;
        Bomb.OnDestroyBomb -= ShakeCamera;
        TrashHealth.OnCollision -= ShakeCamera;
    }
    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        StopShake();
    }
    private void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cmbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cmbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }
    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cmbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cmbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }
    private void Update()
    {
        if(timer > 0)
        {
            timer-=Time.deltaTime;
            if(timer<=0)
            {
                StopShake();
            }
        }
    }
}
