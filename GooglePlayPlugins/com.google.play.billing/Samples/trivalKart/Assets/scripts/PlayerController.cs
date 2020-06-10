using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    public GameObject cam;
    public GameObject tapToDriveText;
    public Animator animator;
    [FormerlySerializedAs("MovementSpeed")] public float force = 6;

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
    private Vector3 _carStartPos;
    private Rigidbody2D _rigidbody2D;
    private static readonly int Speed = Animator.StringToHash("speed");
    
    public void Start()
    { 
        _carStartPos = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gasLevel = 5;
        _fullGasLevel = 5;
        _gasStatus = new GameObject[_fullGasLevel];
        _gasStatus[0] = gasStatus0;
        _gasStatus[1] = gasStatus1;
        _gasStatus[2] = gasStatus2;
        _gasStatus[3] = gasStatus3;
        _gasStatus[4] = gasStatus4;
        _gasStatus[5] = gasStatus5;
        
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            if (_gasLevel > 0)
            {
                Drive();
                _gasLevel--;
                for (var i = 0; i < _fullGasLevel; i++)
                {
                    _gasStatus[i].SetActive(i == _gasLevel);
                }
            }
            else
            {
                noGasText.SetActive(true);
            }
        }
        animator.SetFloat(Speed,  _rigidbody2D.velocity.magnitude);
    }

    private void FixedUpdate()
    {
      if (cam.transform.position.x >= 29)
      {
          transform.position = _carStartPos;
      }
    }

    private void Drive()
    {
        if (tapToDriveText.activeInHierarchy)
        {
            tapToDriveText.SetActive(false);
        }
        _rigidbody2D.AddForce(new Vector2(force,0));
    }
}
