using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private CinemachineVirtualCamera cmVCam;
    private float shakeTimer;


    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin shaker = cmVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        shaker.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    void Awake()
    {
        Instance = this;
        cmVCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin shaker = cmVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                shaker.m_AmplitudeGain = 0f;
            }
        }
    }
}
