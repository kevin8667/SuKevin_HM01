using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 5;

    protected override void Collect(Player player)
    {
        //pull motor contorller form the player
        TankController controller = player.GetComponent<TankController>();

        if(controller != null)
        {
            controller.MaxSpeed += _speedAmount;
        }
    }
}
