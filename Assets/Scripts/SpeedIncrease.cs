using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 1;

    protected override void Collect(Player player)
    {
        //pull motor contorller form the player
        TankController controller = player.GetComponent<TankController>();

        if(controller != null)
        {
            controller.MoveSpeed += _speedAmount;
        }
    }

    protected override void Movement(Rigidbody rb)
    {
        //calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
