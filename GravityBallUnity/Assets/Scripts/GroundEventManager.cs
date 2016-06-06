using UnityEngine;

public class GroundEventManager : MonoBehaviour
{

    public GameObject player;

    public void OnObjectCollidesWithWall(Collision2D collision)
    {

        Transform target = collision.gameObject.transform;
        Rigidbody2D rigBod2D = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector3 collNormal = collision.contacts[0].normal.normalized;

        float temp = collNormal.x;

        Debug.Log("NORMAL: " + collNormal);

        Vector2 movDir = rigBod2D.velocity.normalized;

        Debug.Log("MOV DIR: " + movDir);

        Vector2 newDir = Vector2.Reflect(movDir, collNormal).normalized;

        Debug.Log("NEW DIR: " + newDir);

        //float angle = Vector2.Angle(newDir, collNormal);
        float angle = Vector2.Angle(newDir, collNormal);

        Debug.Log("ANGLE: " + angle);



        target.rotation *= Quaternion.Euler(0, 0, angle);
        //target.rotation = Quaternion.FromToRotation(collNormal, newDir);




        ////For Reflecting The Bullet
        //Vector3 reflectedPosition = Vector3.Reflect(collision.gameObject.GetComponent<Rigidbody2D>().velocity.normalized, collision.contacts[0].normal);
        //rigBod2D.velocity = (reflectedPosition).normalized * 20;

        ////For Rotate The Bullet Towards its velocity
        //Vector3 dir = rigBod2D.velocity;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //rigBod2D.MoveRotation(angle);

        ////-See more at: http://www.theappguruz.com/blog/reflect-object-in-unity2d#sthash.tkQMXazm.dpuf
    }

}
