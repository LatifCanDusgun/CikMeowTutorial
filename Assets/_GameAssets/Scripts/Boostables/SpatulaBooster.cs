using System;
using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostables
{
    [Header("References")]
    [SerializeField] private Animator _animator;
    
    [Header("Settings")]
    [SerializeField] private float _jumpForce;
    
    private bool _isActivated;
    
    public void Boots(PlayerController playerController)
    {
        if (_isActivated) { return; }
        
        PlayerBoostAnimation();
        Rigidbody playerRigidbody = playerController.GetPlayerRigidbody();

        playerRigidbody.linearVelocity =
            new Vector3(playerRigidbody.linearVelocity.x, 0, playerRigidbody.linearVelocity.z);
        playerRigidbody.AddForce(transform.forward * _jumpForce, ForceMode.Impulse);
        _isActivated = true;
        Invoke(nameof(ResetActivation), 0.2f);
        AudioManager.Instance.Play(SoundType.SpatulaSound);
    }
    
    private void PlayerBoostAnimation()
    {
        _animator.SetTrigger(Consts.OtherAnimations.IS_SPATULA_JUMPING);
    }

    private void ResetActivation()
    {
       _isActivated = false;
    }
}
