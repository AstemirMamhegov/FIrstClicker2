using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private WarehouseMiner minerPrefab;

    [Header("Extras")]
    [SerializeField] private Deposit elevatorDeposit;
    [SerializeField] private Transform elevatorDepositLocation;
    [SerializeField] private Transform warehouseDepositLocation;

    private List<WarehouseMiner> _miners = new List<WarehouseMiner>();
    public List<WarehouseMiner> Miners => _miners;

    void Start()
    {
        AddMiner();
    }

    public void AddMiner()
    {
        WarehouseMiner newMiner = Instantiate(minerPrefab, warehouseDepositLocation.position, Quaternion.identity);
        newMiner.ElevatorDeposit = elevatorDeposit;
        newMiner.ElevatorDepositLocation = new Vector3(elevatorDepositLocation.position.x, warehouseDepositLocation.position.y);
        newMiner.WarehouseLocation = new Vector3(warehouseDepositLocation.position.x, warehouseDepositLocation.position.y);

        if(_miners.Count > 0)
        {
            newMiner.CollectCapacity = _miners[0].CollectCapacity;
            newMiner.CollectPerSecond = _miners[0].CollectPerSecond;
            newMiner.MoveSpeed = _miners[0].MoveSpeed;
        }

        _miners.Add(newMiner);
    }
}
