using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    public GameObject tapToDriveText;
    public Animator animator;
    [FormerlySerializedAs("MovementSpeed")] public float force = 6;
    
    private Gas _gas;
    private Vector3 _carStartPos;
    private Rigidbody2D _rigidbody2D;
    private static readonly int Speed = Animator.StringToHash("speed");

    public void Start()
    {
        _gas = GetComponent<Gas>();
        _carStartPos = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void OnMouseDown()
    {
        if (_rigidbody2D.velocity.magnitude < 0.01 && _gas.ConsumeGas())
        {
            Drive();
        }
    }

    private void FixedUpdate()
    {
      if (transform.position.x >= 25)
      {
          transform.position = _carStartPos;
      }
      animator.SetFloat(Speed,  _rigidbody2D.velocity.magnitude);
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
