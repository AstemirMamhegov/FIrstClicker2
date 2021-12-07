using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    public static Action OnUpgradeRequest;

    [SerializeField] private TextMeshProUGUI depositGold;
    [SerializeField] private TextMeshProUGUI shaftID;
    [SerializeField] private TextMeshProUGUI shaftLevel;
    [SerializeField] private TextMeshProUGUI newShaftCost;
    [SerializeField] private GameObject newShaftButton;

    private Shaft _shaft;
    // Start is called before the first frame update
    void Awake()
    {
        _shaft = GetComponent<Shaft>();
    }

    // Update is called once per frame
    void Update()
    {
        depositGold.text = _shaft.ShaftDeposit.CurrentGold.ToString();
    }

    public void AddShaft()
    {
        if (GoldManager.Instance.CurrentGold >= ShaftManager.Instance.ShaftCost)
        {
            GoldManager.Instance.RemoveGold(ShaftManager.Instance.ShaftCost);
            ShaftManager.Instance.AddShaft();
            newShaftButton.SetActive(false);
        }
    }

    public void OpenUpgradeContainer()
    {
        if(OnUpgradeRequest != null)
        {
            OnUpgradeRequest.Invoke();
        }

        OnUpgradeRequest?.Invoke();
    }

    public void SetShaftUI(int ID)
    {
        _shaft.ShaftID = ID;
        shaftID.text = (ID + 1).ToString();
    }

    public void SetNewShaftCost(float newCost)
    {
        newShaftCost.text = newCost.ToString();
    }
}
