using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject newWall;
    private GameObject currentWall;
    private bool isDragging = false;
    public int price;
    public GameObject money;

    void Update()
    {
        if (isDragging && Input.GetMouseButtonDown(0))
        {
            PlaceWall();
        }

        if (isDragging)
        {
            DragWall();
        }
    }
    public void StartDragging()
    {
        MoneyCounter m = money.GetComponent<MoneyCounter>();
        if (!isDragging && price <= m.amount)
        {
            Vector3 spawnPosition = GetWorldPosition();
            currentWall = Instantiate(newWall, spawnPosition, Quaternion.identity);
            currentWall.layer = LayerMask.NameToLayer("Obstacle");
            Bounds bounds = currentWall.GetComponent<BoxCollider2D>().bounds;

            GraphUpdateObject guo = new GraphUpdateObject(bounds);

            AstarPath.active.UpdateGraphs(guo);
            AstarPath.active.Scan();
            isDragging = true;
            m.buy(price);
        }
    }
    void DragWall()
    {
        currentWall.transform.position = GetWorldPosition();
    }

    void PlaceWall()
    {
        isDragging = false;
    }

    Vector3 GetWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePoint);
        worldPosition.x = Mathf.Round(worldPosition.x);
        worldPosition.y = Mathf.Round(worldPosition.y);
        return worldPosition;
    }

}