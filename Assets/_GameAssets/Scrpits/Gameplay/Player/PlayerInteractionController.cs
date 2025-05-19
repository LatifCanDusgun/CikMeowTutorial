using System;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
     [SerializeField] private Transform _playerVisualTransform;
     
     private PlayerController _playerController;
     
     private Rigidbody _playerRigidbody;

     private void Awake()
     {
          _playerController = GetComponent<PlayerController>();
          _playerRigidbody = GetComponent<Rigidbody>();
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.gameObject.TryGetComponent<ICollectible>(out var collectible))
          {
               collectible.Collect();
          }
     }

     private void OnCollisionEnter(Collision other)
     {
          if (other.gameObject.TryGetComponent<IBoostables>(out var boostable ))
          {
               boostable.Boots(_playerController);
          }
     }

     private void OnParticleCollision(GameObject other)
     {
          if (other.TryGetComponent<IDamageable>(out var damageable))
          {
               damageable.GiveDamge(_playerRigidbody, _playerVisualTransform);
          }
     }
}
