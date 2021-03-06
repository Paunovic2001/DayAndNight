using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    public bool stayOpen = false;
    public bool isOpened;
    public bool enableOnReturn = true;
    bool canHurt = true;

    public Vector2 startPos;
    public Vector2 endPos;

    Vector2 globalStartPos;
    Vector2 globalEndPos;

    public float moveSpeed = 5;
    private void Start()
    {
        
        globalStartPos = startPos + new Vector2(transform.position.x, transform.position.y);
        globalEndPos = endPos + new Vector2(transform.position.x, transform.position.y);
    }

    public void MoveBladeTo()
    {
        StartCoroutine(MoveToAnimation());
    }
    public void MoveBladeFrom()
    {
        StartCoroutine(MoveFromAnimation());
    }

    
    IEnumerator MoveToAnimation()
    {
        while (true)
        {
            if (transform.position.x >= globalEndPos.x && transform.position.y >= globalEndPos.y)
            {
                isOpened = true;
                //if(stayOpen == false)
                //{
                //    StartCoroutine(CloseDoorAnimation());
                //}
                break;
            }
            transform.position += new Vector3(0, Time.deltaTime * moveSpeed, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveFromAnimation()
    {
        yield return new WaitUntil(() => isOpened == true);
        
        while (stayOpen == false)
        {
            if (transform.position.x <= globalStartPos.x && transform.position.y <= globalStartPos.y)
            {
                isOpened = false;
                break;
            }
            transform.position += new Vector3(0, Time.deltaTime * moveSpeed * -1, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    void OnDrawGizmos()
    {
        if (startPos != null && endPos != null)
        {
            Gizmos.color = Color.cyan;
            float size = .3f;

            Vector2 globalWaypointPos = (Application.isPlaying) ? globalStartPos : startPos + new Vector2(transform.position.x, transform.position.y);
            Gizmos.DrawLine(globalWaypointPos - Vector2.up * size, globalWaypointPos + Vector2.up * size);
            Gizmos.DrawLine(globalWaypointPos - Vector2.left * size, globalWaypointPos + Vector2.left * size);
            globalWaypointPos = (Application.isPlaying) ? globalEndPos : endPos + new Vector2(transform.position.x, transform.position.y);
            Gizmos.DrawLine(globalWaypointPos - Vector2.up * size, globalWaypointPos + Vector2.up * size);
            Gizmos.DrawLine(globalWaypointPos - Vector2.left * size, globalWaypointPos + Vector2.left * size);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerDay" || collision.tag == "PlayerNight")
        {
            collision.GetComponent<Player>().Respawn();
        }
    }
}
