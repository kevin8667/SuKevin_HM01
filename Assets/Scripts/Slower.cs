using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _speedAmountDecreased = 0.05f;
    protected override void PlayerImpact(Player player)
    {
        TankController controller = player.GetComponent<TankController>();

        if (controller != null)
        {
            controller.MoveSpeed -= _speedAmountDecreased;
        }
    }
}
