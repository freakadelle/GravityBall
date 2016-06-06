using UnityEngine;
using System.Collections;

public class EnergyBallBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;

    public GameObject target;
    [SerializeField, Range(0, 100)]
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //rb.AddForce(transform.up * speed * 10);
    }

    void FixedUpdate()
    {
        //Quaternion rot = Quaternion.LookRotation(transform.position - target.transform.position);
        //transform.rotation = rot;
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        rb.AddForce(transform.up * speed);
    }


}
