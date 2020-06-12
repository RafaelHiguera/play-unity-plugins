using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject tab;
    public GameObject gasPage;

    public GameObject coinPage;

    private GameObject[] tabs;

    private int tabsCount;
    // Start is called before the first frame update
    void Start()
    {
        tabsCount = tab.transform.childCount;
        tabs = new GameObject[tabsCount];
        for (int i = 0; i < tabsCount; i++)
        {
            tabs[i] = tab.transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGasPage()
    {
        gasPage.SetActive(true);
        coinPage.SetActive(false);
        SetTab(0);
    }

    public void EnterCoinPage()
    {
        coinPage.SetActive(true);
        gasPage.SetActive(false);
        SetTab(1);
    }

    void SetTab(int targetTagIndex)
    {
        for (int i = 0; i < tabsCount; i++)
        {
            if (i == targetTagIndex)
            {
                tabs[i].transform.GetChild(0).gameObject.SetActive(false);
                tabs[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                tabs[i].transform.GetChild(0).gameObject.SetActive(true);
                tabs[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}
