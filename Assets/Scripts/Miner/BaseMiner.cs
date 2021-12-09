using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class BaseMiner : MonoBehaviour, IClickable
{
    [Header("Initial Values")]
    [SerializeField] private float initialCollectCapacity;
    [SerializeField] private float initialCollectPerSecond;
    [SerializeField] protected float moveSpeed;

    public float CurrentGold { get; set; }
    public float CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }
    public bool IsTimeCollect { get; set; }
    public bool MinerClicked {get;set;}
    public float MoveSpeed { get; set; }

    protected Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        IsTimeCollect = true;

        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = initialCollectPerSecond;
        MoveSpeed = moveSpeed;
    }

    private void OnMouseDown()
    {
        if (!MinerClicked)
        {
            OnClick();
            MinerClicked = true;
        }
    }

    public virtual void OnClick()
    {

    }

    protected virtual void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, MoveSpeed).SetEase(Ease.Linear).OnComplete((() => 
        {
            if (IsTimeCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }

        })).Play();
    }

    protected virtual void CollectGold()
    {

    }

    protected virtual IEnumerator IECollect(float gold, float collectTime)
    {
        yield return null;
    }

    protected virtual void DepositGold()
    {

    }

    protected virtual IEnumerator IEDeposit(float depositTime)
    {
        yield return null;
    }

    protected void ChangeGoal()
    {
        IsTimeCollect = !IsTimeCollect;
    }

    protected void RotateMiner(int direction)
    {
        if(direction == 1)
        {
            transform.localScale = new Vector3(x: 1, y:1, z: 1);
        }
        else
        {
            transform.localScale = new Vector3(x: -1, y: 1, z: 1);
        }
    }
}
