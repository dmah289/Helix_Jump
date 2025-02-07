using System;
using UnityEngine;

namespace Controller
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _cam;
        
        [Header("Logic")]
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothSpeed = 0.04f;

        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("Ball").transform;
            _cam = transform;
        }

        private void Start()
        {
            _offset = _cam.position - _target.position;
        }

        private void LateUpdate()
        {
            _cam.position = Vector3.Lerp(_cam.position, _target.position + _offset, _smoothSpeed);
        }
    }
}