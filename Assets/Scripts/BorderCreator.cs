using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCreator : MonoBehaviour
{
    public float wallThickness = 1f;
    public float wallHeight = 10f;
    public float distanceFromCenter = 50f;
    public Color wallColor = new Color(0.6f, 0.4f, 0.2f);

    // Start is called before the first frame update
    void Start()
    {
        CreateWalls();
    }

    void CreateWalls()
    {
        float wallLength = distanceFromCenter * 2;

        CreateWall(new Vector2(0, distanceFromCenter), wallLength, wallThickness); // Top wall
        CreateWall(new Vector2(0, -distanceFromCenter), wallLength, wallThickness); // Bottom wall
        CreateWall(new Vector2(distanceFromCenter, 0), wallThickness, wallLength); // Right wall
        CreateWall(new Vector2(-distanceFromCenter, 0), wallThickness, wallLength); // Left wall
    }

    void CreateWall(Vector2 position, float width, float height)
    {
        GameObject wall = new GameObject("Wall");
        wall.transform.position = new Vector3(position.x, 0, position.y);

        SpriteRenderer renderer = wall.AddComponent<SpriteRenderer>();
        renderer.color = wallColor;

        BoxCollider2D collider = wall.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(width, height);

        wall.transform.localScale = new Vector3(width, wallHeight, height);
    }
}
