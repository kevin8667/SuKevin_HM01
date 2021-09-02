using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerUpDuration = 5f;
    protected float PowerUpDuration => _powerUpDuration;

    [SerializeField] float _movementSpeed = 1;

    protected float MovementSpeed => _movementSpeed;
    
    protected abstract void Collect(Player player);

    Rigidbody _rb;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    bool _poweredUp = false;


    //[SerializeField] GameObject _visualsToDeactivate = null;

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
    }

    protected virtual void Movement(Rigidbody rb)
    {
        //calculate rotation
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            //spawn particles & sfx because we need tp disable object
            Feedback();
            
            gameObject.SetActive(false);
        }
    }

   

    protected abstract void Powerup(Player player);


    protected abstract void PowerDown(Player player);


    /**protected void DisableObject()
    {
        //disable collider
        _colliderToDeactivate.enabled = false;
        //disable visual
        _visualsToDeactivate.SetActive(false);
    }**/

    protected void Feedback()
    {
        //particles
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);

        }
        //audio
        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
}

