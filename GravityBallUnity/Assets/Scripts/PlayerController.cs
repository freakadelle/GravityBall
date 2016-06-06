using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField, Range(-20, 20)]
    public int mobility;
    [SerializeField, Range(0, 100)]
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //Debug.Log(transform.rotation * transform.up);

        float input = Input.GetAxis("Horizontal") * - mobility;
        transform.rotation *= Quaternion.Euler(0, 0, input);

        rb.AddForce(transform.up * speed);
    }

    public void turnPlayerByDegrees(int degrees)
    {
        transform.rotation *= Quaternion.Euler(0, 0, degrees);
    }

    public void reflectToNormal(Vector3 normal)
    {
        
    }
}
