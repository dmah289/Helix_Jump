using System;
using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace Model
{
    public class HelixRing : MonoBehaviour
    {
        [SerializeField] private Transform _ball;
        [SerializeField] private GameObject[] childRings;

        [SerializeField] private float _radius;
        [SerializeField] private float _force;
        [SerializeField] private bool passed;

        private void Awake()
        {
            passed = false;
            _ball = GameObject.FindGameObjectWithTag("Ball").transform;
        }

        private void Update()
        {
            if (transform.position.y > _ball.position.y + 0.1f && !passed)
            {
                passed = true;
                AudioManager.Instance.PlaySound("Whoosh");
                GameManager.noOfPassedRings++;
                for (int i = 0; i < childRings.Length; i++)
                {
                    childRings[i].GetComponent<Rigidbody>().isKinematic = false;
                    childRings[i].GetComponent<Rigidbody>().useGravity = true;

                    Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

                    foreach (Collider c in colliders)
                    {
                        Rigidbody rb = c.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.AddExplosionForce(_force, transform.position, _radius);
                        }
                    }
                    childRings[i].GetComponent<MeshCollider>().enabled = false;
                    childRings[i].transform.parent = null;
                    Destroy(childRings[i], 2);
                }
                Destroy(gameObject, 5);
                this.enabled = false;
            }
        }
    }
}