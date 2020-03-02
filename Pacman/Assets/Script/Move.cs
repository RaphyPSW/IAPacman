using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.1f;
    Vector2 dest = Vector2.zero;

    void Start()
    {
        dest = transform.position;
    }

    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        Debug.Log( "dest" +dest.x + " , " + dest.y);
        Debug.Log("pacman" + transform.position.x + " , " + transform.position.y);
        /*if ((Vector2)transform.position == dest)
        {*/
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
            
       // }

        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("directionX", dir.x);
        GetComponent<Animator>().SetFloat("directionY", dir.y);

    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider.CompareTag("dots") || hit.collider == GetComponent<Collider2D>());
    }
}
