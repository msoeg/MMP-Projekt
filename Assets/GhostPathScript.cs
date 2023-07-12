using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPathScript : MonoBehaviour
{
    public GameObject ghost;
    public CapsuleCollider2D ghostCapsule;
    public SpriteRenderer ghostSpriteRenderer;

    public GameObject[] path;

    public int numberOfPoints;

    public float speed;

    private Vector3 actualPosition;

    private int x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = ghost.transform.position;
        ghostCapsule.enabled = x % 2 != 0;
        ghostSpriteRenderer.enabled = x % 2 != 0;

        if (x > 0 && x < numberOfPoints ) ghostSpriteRenderer.flipX = path[x].transform.position.x < path[x - 1].transform.position.x;
        else ghostSpriteRenderer.flipX = false;

        ghost.transform.position =
            Vector3.MoveTowards(actualPosition, path[x].transform.position, speed * Time.deltaTime);
        
        if (actualPosition == path[x].transform.position)
        {
            if (x < numberOfPoints - 1) x++;
            else x = 0;
        }
    }
}
