using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private ShaftMiner minerPrefab;
    [SerializeField] private Deposit depositPrefab;

    [Header("Locations")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private Transform depositCreationLocation;

    public int ShaftID { get; set; }
    public Transform MiningLocation => miningLocation;
    public Transform DepositLocation => depositLocation;
    public Deposit ShaftDeposit { get; set; }
    public ShaftUI ShaftUI { get; set; }

    private void Awake()
    {
        ShaftUI = GetComponent<ShaftUI>();
    }
    void Start()
    {
        ShaftUI = GetComponent<ShaftUI>();
        CreateMiner();
        CreateDeposit();
    }

    private void CreateMiner()
    {
        ShaftMiner newMiner = Instantiate(minerPrefab, depositLocation.position, rotation: (Quaternion)Quaternion.identity);
        newMiner.CurrentShaft = this;
        newMiner.transform.SetParent(transform);
    }

    private void CreateDeposit()
    {
        ShaftDeposit = Instantiate(depositPrefab, depositCreationLocation.position, rotation: (Quaternion)Quaternion.identity);
        ShaftDeposit.transform.SetParent(transform);
    }
}
