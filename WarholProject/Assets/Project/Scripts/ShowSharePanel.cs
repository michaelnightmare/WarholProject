using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowSharePanel : MonoBehaviour
{
    public GameObject ShowingSharePanel;
    public GameObject HideSharePanel;

    public void Show()
    {
        GetComponent<Button>().onClick.AddListener(() => { ShowingSharePanel.SetActive(true); });

    }
    public void HidePanel()
    {
        GetComponent<Button>().onClick.AddListener(() => { ShowingSharePanel.SetActive(false); });
    }

}
