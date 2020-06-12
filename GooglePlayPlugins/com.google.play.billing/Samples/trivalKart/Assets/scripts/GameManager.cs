using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playPageCanvas;

    public GameObject storePageCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterStore()
    {
        print("clicked store");
        storePageCanvas.SetActive(true);
        playPageCanvas.SetActive(false);
    }

    public void EnterPlayPage()
    {
        storePageCanvas.SetActive(false);
        playPageCanvas.SetActive(true);
    }
}
