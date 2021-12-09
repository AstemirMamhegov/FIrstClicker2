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
    public List<ShaftMiner> Miners => _miners;

    private List<ShaftMiner> _miners = new List<ShaftMiner>();

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

    public void CreateMiner()
    {
        ShaftMiner newMiner = Instantiate(minerPrefab, depositLocation.position, rotation: (Quaternion)Quaternion.identity);
        newMiner.CurrentShaft = this;
        newMiner.transform.SetParent(transform);

        if(_miners.Count > 0)
        {
            newMiner.CollectCapacity = _miners[0].CollectCapacity;
            newMiner.CollectPerSecond = _miners[0].CollectPerSecond;
            newMiner.MoveSpeed = _miners[0].MoveSpeed;
        }

        _miners.Add(newMiner);
    }

    private void CreateDeposit()
    {
        ShaftDeposit = Instantiate(depositPrefab, depositCreationLocation.position, rotation: (Quaternion)Quaternion.identity);
        ShaftDeposit.transform.SetParent(transform);
    }
}
