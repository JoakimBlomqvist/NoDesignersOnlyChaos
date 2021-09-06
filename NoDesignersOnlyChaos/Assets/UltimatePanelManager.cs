using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimatePanelManager : MonoBehaviour
{
    [SerializeField]private GameObject ultimatePanel;

    public void OpenUltimatePanel()
    {
        ultimatePanel.SetActive(true);
    }

    public void CloseUltimatePanel()
    {
        ultimatePanel.SetActive(false);
    }
}
