using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakingController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f,shakeTime = 0.5f;
    public Camera mainCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking",0f,0.05f);
        Invoke("StopCameraShaking",shakeTime);
    }
    void StartCameraShaking()
    {
        float cameraShakingOffSetX = Random.value * shakeMagnitude * 2 -shakeMagnitude;
         float cameraShakingOffSetY = Random.value * shakeMagnitude * 2 -shakeMagnitude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffSetX;
        cameraIntermadiatePosition.y +=cameraShakingOffSetY;
        mainCamera.transform.position=cameraIntermadiatePosition;
    }
    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }

}
