using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : PowerUpBase
{
    bool _poweredUp = false;



    protected override void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            //spawn particles & sfx because we need tp disable object
            Feedback();

        }
    }

    protected override void Collect(Player player)
    {
        if (_poweredUp == false) 
        {
            StartCoroutine(PowerupSequence(player));
        }
        

    }

    protected override void Powerup(Player player)
    {

        player._isInvincible = true;
        Debug.Log("Player is invincible.");
        
        
    }
    protected override void PowerDown(Player player) 
    {
        player._isInvincible = false;
        Debug.Log("Player is not invincible.");

        
    }

    IEnumerator PowerupSequence(Player player)
    {
        //set boolean for detecting lockout
        _poweredUp = true;

        Powerup(player);
        
       GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;

        //wait for the required dduration
        yield return new WaitForSeconds(PowerUpDuration);
        //destroy
        PowerDown(player);
        Destroy(gameObject);


        //set boolean to release lockout
        _poweredUp = false;

    }

}

