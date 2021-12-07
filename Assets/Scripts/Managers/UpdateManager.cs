using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeContainer;

    public void OpenCloseUpgradeContainer(bool status)
    {
        upgradeContainer.SetActive(status);
    }

    private void ShaftUpgradeRequest()
    {
        OpenCloseUpgradeContainer(true);
    }

    private void OnEnable()
    {
        ShaftUI.OnUpgradeRequest += ShaftUpgradeRequest;
    }

    private void OnDisable()
    {
        ShaftUI.OnUpgradeRequest -= ShaftUpgradeRequest;
    }
}
