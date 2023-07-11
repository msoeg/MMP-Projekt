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
        
        ghost.transform.position =
            Vector3.MoveTowards(actualPosition, path[x].transform.position, speed * Time.deltaTime);

        if (actualPosition == path[x].transform.position && x != numberOfPoints - 1) x++;
        //else x = 0;
        else if (x == numberOfPoints - 1) x = 0;
    }
}
