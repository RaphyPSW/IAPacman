using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFindingTest : MonoBehaviour
{

    private Pathfinding pathfinding;

    [SerializeField] GameObject pacmanPrefab;
    Transform pacmanParent;

    private void Awake()
    {
        pacmanParent = new GameObject().transform;
        pacmanPrefab = Resources.Load<GameObject>("Prefabs/pacman");


    }
    private void Start()
    {
         this.pathfinding = new Pathfinding(10, 10);
        Instantiate(pacmanPrefab);

    }

    private void Update()
    {
        
           // GameObject pacman = GameObject.Instantiate(pacmanPrefab, pacmanParent);
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            Debug.Log(mouseWorldPosition.x + ", " + mouseWorldPosition.y);
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            
            
            Debug.Log("inside Input");
            if(path != null)
            {
                Debug.Log("inside path");
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);
                }
            }
        

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition2 = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition2, out int x2, out int y2);
            pathfinding.GetNode(x2, y2).SetIsWalkable(!pathfinding.GetNode(x2, y2).isWalkable);
        }
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
