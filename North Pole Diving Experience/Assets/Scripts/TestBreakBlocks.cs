using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TestBreakBlocks : MonoBehaviour
{
    public float timeToBreakIce = 2f;
    public GameObject player;
    public float maxDistanceToBreak = 2f;
    private float currentTimeToBreakIce = 0;
    private Vector3Int currentBreakPos;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePosition;

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

        if(Mouse.current.leftButton.isPressed)
            foreach(var hit in hits)
            {
                if (hit.collider != null)
                {
                    print(hit.collider.name);
                    if(hit.collider.name == "Breakable Grounds")
                    {
                        if(((Vector2)player.transform.position - (Vector2)mousePosition).magnitude < maxDistanceToBreak)
                        {
                            Tilemap tilemap = hit.collider.GetComponent<Tilemap>();

                            Vector2 extraOffset = new Vector2();

                            if(hit.point.y < 0)
                            {
                                extraOffset.y = -1;
                            }
                            if (hit.point.x < 0)
                            {
                                extraOffset.x = -1;
                            }

                            Vector3Int newBreakPos = new Vector3Int((int)hit.point.x + (int)extraOffset.x, (int)hit.point.y + (int)extraOffset.y, 0);

                            if (currentBreakPos != newBreakPos)
                            {
                                currentTimeToBreakIce = 0;
                            }
                            else
                            {
                                currentTimeToBreakIce += Time.deltaTime;
                            }

                            currentBreakPos = newBreakPos;

                            if(currentTimeToBreakIce >= timeToBreakIce)
                            {
                                tilemap.SetTile(currentBreakPos,null);
                            }
                        }
                    }
                }
            }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    //print("SOMETHING");
    //    //print(collision);
    //    Vector2 point = collision.ClosestPoint(transform.position);
    //    print(point);
    //    Vector3Int pointInt = new Vector3Int((int)point.x,(int)point.y,0);
    //    breakableTilemap.SetTile(pointInt, null);
    //    print("Broke at " + pointInt);
    //}
}
