using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class BaseMiner : MonoBehaviour
{
    [SerializeField] protected Transform miningLocation;
    [SerializeField] protected Transform depositLocation;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Deposit shaftDeposit;

    [Header("Initial Values")]
    [SerializeField] private float initialCollectCapacity;
    [SerializeField] private float initialCollectPerSecond;

    public float CurrentGold { get; set; }
    public float CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }
    public bool IsTimeCollect { get; set; }

    protected Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        IsTimeCollect = true;

        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = initialCollectPerSecond;
    }
    protected virtual void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, moveSpeed).SetEase(Ease.Linear).OnComplete((() => 
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 xPos = new Vector3(miningLocation.position.x, transform.position.y);
            MoveMiner(xPos);
        }
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
