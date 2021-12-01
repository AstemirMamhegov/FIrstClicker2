using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    protected override void CollectGold()
    {
        ChangeGoal();
        RotateMiner(direction: - 1);
        Vector3 depositPos = new Vector3(depositLocation.position.x, transform.position.y);
        MoveMiner(depositPos);
    }

    protected override void DepositGold()
    {
        ChangeGoal();
        RotateMiner(direction: 1);
        Vector3 xPos = new Vector3(miningLocation.position.x, transform.position.y);
        MoveMiner(xPos);
    }
}
