using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int _treausreAdded= 1;

    protected override void Collect(Player player)
    {
        player.TreasureCount += _treausreAdded;
        player.UpdateDisplay(player);
        
    }
    protected override void Movement(Rigidbody rb)
    {
        //calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, 0, 0);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
