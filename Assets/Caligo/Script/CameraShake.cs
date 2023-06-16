using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float shakeDistance;
    public float shakeSpeed;

    Vector3 initialPosition;
    Vector3 shakeOffset;

    bool isCameraShaking = false;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCameraShaking)
        {
            Vector3 pos = transform.position;
            Vector3 offsetPosition = pos + shakeOffset;
            float currentDistance = offsetPosition.y - initialPosition.y;
            if(shakeSpeed >= 0)
            {
                if(currentDistance > shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }
            else
            {
                  if(currentDistance < -shakeDistance)
                  {
                    shakeSpeed *= -1;
                  }
            }
            shakeOffset.y += shakeSpeed * Time.deltaTime;
            if (shakeOffset.y > shakeDistance) shakeOffset.y = shakeDistance;
            if (shakeOffset.y < -shakeDistance) shakeOffset.y = -shakeDistance;
            transform.position = initialPosition + shakeOffset;
        }   
    }
    public void StartShaking()
    {
        {
            isCameraShaking = true;
        }
        
    }

    public void StopShaking()
    {
        isCameraShaking = false;
        transform.position = initialPosition;
    }


}
