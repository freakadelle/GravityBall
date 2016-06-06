using UnityEngine;
using System.Collections;

// @NOTE the attached sprite's position should be "top left" or the children will not align properly
// Strech out the image as you need in the sprite render, the following script will auto-correct it when rendered in the game

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
public class RepeatSpriteBoundary : MonoBehaviour
{

    //private SpriteRenderer sprite;

    public bool createBoundsCollider;
    [SerializeField, Range(0, 100)]
    public int repeatX;
    [SerializeField, Range(0, 100)]
    public int repeatY;
    [SerializeField, Range(-2, 2)]
    public float scale = 1;

    void Start()
    {
        
    }

    void Awake()
    {
        GameObject groundTileInstance = Resources.Load("Prefabs/Ground_Stone_Tile", typeof(GameObject)) as GameObject;
        SpriteRenderer sprite = groundTileInstance.GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        groundTileInstance.transform.position = transform.position;

        GameObject child;

        for (int x = 0; x < repeatX; x++)
        {
            for (int y = 0; y < repeatY; y++)
            {
                child = Instantiate(groundTileInstance);
                child.transform.position = new Vector3(spriteSize.x * x, spriteSize.y * y, 0);
                child.transform.parent = transform;

                //if (createBoundsCollider && (y <= 0 || x <= 0 || y >= repeatY - 1 || x >= repeatX - 1))
                //{
                //    child.GetComponent<BoxCollider2D>().enabled = true;
                //    child.GetComponent<WallBehaviour>().enabled = true;
                //}
            }
        }

        if (createBoundsCollider)
        {

            child = new GameObject("WallColliderNorth");
            child.AddComponent<EdgeCollider2D>();
            child.transform.position = new Vector3(spriteSize.x * (repeatX - 0.5f) / 2.0f, spriteSize.y * (repeatY - 0.5f), 0);
            child.transform.localScale = new Vector3(repeatX * 7, 0, 0);
            child.AddComponent<WallBehaviour>();
            child.transform.parent = transform;

            child = new GameObject("WallColliderSouth");
            child.AddComponent<EdgeCollider2D>();
            child.transform.position = new Vector3(spriteSize.x * (repeatX - 0.5f) / 2.0f, -(spriteSize.y / 2), 0);
            child.transform.localScale = new Vector3(repeatX * 7, 0, 0);
            child.AddComponent<WallBehaviour>();
            child.transform.parent = transform;

            child = new GameObject("WallColliderEast");
            child.AddComponent<EdgeCollider2D>();
            child.transform.rotation = Quaternion.Euler(0, 0, 90);
            child.transform.position = new Vector3(spriteSize.x * (repeatX - 0.5f), spriteSize.y * (repeatY - 0.5f) / 2.0f, 0);
            child.transform.localScale = new Vector3(repeatY * 7, 0, 0);
            child.AddComponent<WallBehaviour>();
            child.transform.parent = transform;

            child = new GameObject("WallColliderWest");
            child.AddComponent<EdgeCollider2D>();
            child.transform.rotation = Quaternion.Euler(0, 0, -90);
            child.transform.position = new Vector3(-(spriteSize.x / 2), spriteSize.y * (repeatY - 0.5f) / 2.0f, 0);
            child.transform.localScale = new Vector3(repeatY * 7, 0, 0);
            child.AddComponent<WallBehaviour>();
            child.transform.parent = transform;

        }

        //Resize mao to desired size
        transform.localScale = new Vector3(scale, scale, scale);

        
    }
}