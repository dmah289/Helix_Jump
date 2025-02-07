using System;
using Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _bounceForce = 400f;
        
        [SerializeField] private GameObject _splashPrefab;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            AudioManager.Instance.PlaySound("Land");
            
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, _bounceForce * Time.deltaTime, _rb.linearVelocity.z);
            GameObject newSplash = Instantiate(_splashPrefab, new Vector3(transform.position.x, other.transform.position.y + 0.2f, transform.position.z), transform.rotation);
            newSplash.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
            newSplash.transform.SetParent(other.transform);

            string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

            if (materialName == "DangerousArea (Instance)")
            {
                GameManager.isGameOver = true;
                AudioManager.Instance.PlaySound("GameOver");
            }
            else if (materialName == "BottomRing (Instance)" && !GameManager.levelWin)
            {
                GameManager.levelWin = true;
                AudioManager.Instance.PlaySound("LevelWin");
            }
        }
    }
}