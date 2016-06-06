using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class WallBehaviour : MonoBehaviour {

    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "EnergyBall")
        {
            SendMessageUpwards("OnObjectCollidesWithWall", coll);
        }
    }

}
