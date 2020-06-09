using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public GameObject tapToDriveText;
    public Animator animator;
    [FormerlySerializedAs("MovementSpeed")] public float force = 6;
    private Vector3 _carStartPos;
    private Rigidbody2D _rigidbody2D;
    private static readonly int Speed = Animator.StringToHash("speed");
    
    public void Start()
    { 
        _carStartPos = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            Drive();
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
