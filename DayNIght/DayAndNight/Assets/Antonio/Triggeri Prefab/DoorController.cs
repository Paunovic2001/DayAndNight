using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorController : RaycastController
{
    public bool stayOpen = false;
    [HideInInspector] public bool isOpened;
    public Vector2 startPos;
    public Vector2 endPos;
    public float doorSpeed = 10;

    Vector2 globalStartPos;
    Vector2 globalEndPos;

    private void Start()
    {
        globalStartPos = startPos + new Vector2 (transform.position.x, transform.position.y);
        globalEndPos = endPos + new Vector2 (transform.position.x, transform.position.y);
    }

    public void OpenDoor()
    {
        StartCoroutine(OpenDoorAnimation());
    }
    public void CloseDoor()
    {
        StartCoroutine(CloseDoorAnimation());
    }

    IEnumerator OpenDoorAnimation()
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
            transform.position += new Vector3(0, Time.deltaTime * doorSpeed, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CloseDoorAnimation()
    {
        yield return new WaitUntil(() => isOpened == true);

        while (stayOpen == false)
        {
            if (transform.position.x <= globalStartPos.x && transform.position.y <= globalStartPos.y)
            {
                isOpened = false;
                break;
            }
            transform.position += new Vector3(0, Time.deltaTime * doorSpeed * -1, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    void OnDrawGizmos()
    {
        if (startPos != null && endPos != null)
        {
            Gizmos.color = Color.blue;
            float size = .3f;

                Vector2 globalWaypointPos = (Application.isPlaying) ? globalStartPos : startPos + new Vector2(transform.position.x, transform.position.y);
                Gizmos.DrawLine(globalWaypointPos - Vector2.up * size, globalWaypointPos + Vector2.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector2.left * size, globalWaypointPos + Vector2.left * size);
                globalWaypointPos = (Application.isPlaying) ? globalEndPos : endPos + new Vector2(transform.position.x, transform.position.y);
                Gizmos.DrawLine(globalWaypointPos - Vector2.up * size, globalWaypointPos + Vector2.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector2.left * size, globalWaypointPos + Vector2.left * size);
        }
    }
}
