using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    private int walkAnimation = Animator.StringToHash(name: "Walk");
    private int miningAnimation = Animator.StringToHash(name: "Mining");
    protected override void MoveMiner(Vector3 newPosition)
    {
        base.MoveMiner(newPosition);
        _animator.SetTrigger(walkAnimation);
    }
    protected override void CollectGold()
    {
        _animator.SetTrigger(miningAnimation);
        float collectTime = CollectCapacity / CollectPerSecond;
        StartCoroutine(routine: IECollect(gold: CollectCapacity, collectTime));
    }

    protected override IEnumerator IECollect(float gold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = gold;
        ChangeGoal();
        RotateMiner(direction: -1);
        Vector3 depositPos = new Vector3(depositLocation.position.x, transform.position.y);
        MoveMiner(depositPos);
    }

    protected override void DepositGold()
    {
        shaftDeposit.DepositGold(CurrentGold);

        CurrentGold = 0;
        ChangeGoal();
        RotateMiner(direction: 1);
        Vector3 xPos = new Vector3(miningLocation.position.x, transform.position.y);
        MoveMiner(xPos);
    }
}
