using System;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public GameObject gasStatus0;
    public GameObject gasStatus1;
    public GameObject gasStatus2;
    public GameObject gasStatus3;
    public GameObject gasStatus4;
    public GameObject gasStatus5;
    public GameObject noGasText;
    
    private int _gasLevel;
    private GameObject[] _gasStatus;
    private int _fullGasLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        _gasLevel = 5;
        _fullGasLevel = 5;
        _gasStatus = new GameObject[_fullGasLevel + 1];
        _gasStatus[0] = gasStatus0;
        _gasStatus[1] = gasStatus1;
        _gasStatus[2] = gasStatus2;
        _gasStatus[3] = gasStatus3;
        _gasStatus[4] = gasStatus4;
        _gasStatus[5] = gasStatus5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetGasLevel()
    {
        return _gasLevel;
    }

    public bool ConsumeGas()
    {
        if (_gasLevel > 0)
        {
            _gasLevel -= 1;
            for (var i = 0; i <= _fullGasLevel; i++)
            {
                _gasStatus[i].SetActive(i == _gasLevel);
            }
            return true;
        }
        else
        {
            noGasText.SetActive(true);
            return false;
        }
       
    }
}
