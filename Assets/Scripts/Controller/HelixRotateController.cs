using System;
using Framework;
using UnityEngine;

namespace Controller
{
    public class HelixRotateController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 300f;
        [SerializeField] private float _rotationSpeedApk = 50f;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X");
                transform.Rotate(transform.position.x, -mouseX * _rotationSpeed * Time.deltaTime, transform.rotation.z);
            }
            // #elif UNITY_ANDROID
            // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            // {
            //     float deltaPosX = Input.GetTouch(0).deltaPosition.x;
            //     transform.Rotate(transform.position.x, -deltaPosX * _rotationSpeedApk * Time.deltaTime, transform.rotation.z);
            // }
            // #endif
        }
    }
}