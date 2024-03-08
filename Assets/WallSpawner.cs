using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject newWall;
    private GameObject currentWall;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            StartDragging();
        }
        else if (isDragging && Input.GetMouseButtonDown(0))
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
        if (!isDragging)
        {
            Vector3 spawnPosition = GetWorldPosition();
            currentWall = Instantiate(newWall, spawnPosition, Quaternion.identity);
            isDragging = true;
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
        return worldPosition;
    }

}
