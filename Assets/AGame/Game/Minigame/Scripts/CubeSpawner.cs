using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject errorCubePrefab;
    public int numberOfCubes = 5;
    public int numberOfErrorCubes = 5;
    public float maxInitialForce = 10f;
    public float padding = 2f;
    public float wallThickness = 2f;
    public float boxThickness = 4f;
    public List<Cube> SpawnedCubes = new List<Cube>();

    [SerializeField] private Camera _camera;
    [SerializeField] private CubeChainLogic _cubeChainLogic;

    private float _boxZDistanceFromCamera = 15f;
    private Transform _boxTransform;
    
    void Start()
    {
        Vector3 boxPosition = _camera.transform.position + _camera.transform.forward * _boxZDistanceFromCamera;
        Vector3 boxBounds = CalculateCameraBounds(_camera);

        SetupBoundaryBox(boxPosition, boxBounds);
        SpawnCubesOutsideScreen(boxBounds);
        
        _cubeChainLogic.Initialize(this);
    }
    
    private Vector3 CalculateCameraBounds(Camera camera)
    {
        Vector3 screenBottomLeft = camera.ViewportToWorldPoint(new Vector3(0f, 0f, _boxZDistanceFromCamera));
        Vector3 screenTopRight = camera.ViewportToWorldPoint(new Vector3(1f, 1f, _boxZDistanceFromCamera));
        
        float viewWidth = screenTopRight.x - screenBottomLeft.x;
        float viewHeight = screenTopRight.y - screenBottomLeft.y;
        
        float boxWidth = viewWidth + (padding * 2f);
        float boxHeight = viewHeight + (padding * 2f);
        float boxDepth = boxThickness; 
        
        return new Vector3(boxWidth, boxHeight, boxDepth);
    }

    private void SetupBoundaryBox(Vector3 boxPosition, Vector3 boxBounds)
    {
        GameObject box = new GameObject("Box");
        box.transform.position = boxPosition; 
        _boxTransform = box.transform;
        
        float hx = boxBounds.x / 2f;
        float hy = boxBounds.y / 2f;
        float hz = boxBounds.z / 2f;
        float thickness = wallThickness;

        CreateWall("Wall_Right", new Vector3(hx + thickness / 2f, 0, 0), new Vector3(thickness, boxBounds.y + thickness, boxBounds.z + thickness), box.transform);
        CreateWall("Wall_Left", new Vector3(-hx - thickness / 2f, 0, 0), new Vector3(thickness, boxBounds.y + thickness, boxBounds.z + thickness), box.transform);
        
        CreateWall("Wall_Top", new Vector3(0, hy + thickness / 2f, 0), new Vector3(boxBounds.x + thickness, thickness, boxBounds.z + thickness), box.transform);
        CreateWall("Wall_Bottom", new Vector3(0, -hy - thickness / 2f, 0), new Vector3(boxBounds.x + thickness, thickness, boxBounds.z + thickness), box.transform);
    }
    
    private void CreateWall(string name, Vector3 positionOffset, Vector3 scale, Transform parent)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        Renderer rend = wall.GetComponent<Renderer>();
        if (rend != null) rend.enabled = false;

        wall.name = name;
        wall.transform.SetParent(parent);
        wall.transform.localPosition = positionOffset; 
        wall.transform.localScale = scale; 
    }

    
    private void SpawnCubesOutsideScreen(Vector3 boxBounds)
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 spawnPositionWorld = SpawnPositionWorld(boxBounds);

            GameObject newCube = Instantiate(cubePrefab, spawnPositionWorld, Random.rotation);
            newCube.name = "Cube_" + i;
            Cube c = newCube.GetComponent<Cube>();
            c.Id = i;
            c.Text.text = (i+1).ToString();
            c.Text2.text = (i+1).ToString();
            
            Rigidbody rb = newCube.GetComponent<Rigidbody>();
            
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            float randomForce = Random.Range(maxInitialForce / 2f, maxInitialForce);
                
            rb.AddForce(randomDirection * randomForce, ForceMode.Impulse);
            
            SpawnedCubes.Add(c);
        }
        
        for (int i = 0; i < numberOfErrorCubes; i++)
        {
            Vector3 spawnPositionWorld = SpawnPositionWorld(boxBounds);

            GameObject newCube = Instantiate(errorCubePrefab, spawnPositionWorld, Random.rotation);
            newCube.name = "ErrorCube_" + i;
            Cube c = newCube.GetComponent<Cube>();
            
            Rigidbody rb = newCube.GetComponent<Rigidbody>();
            
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            float randomForce = Random.Range(maxInitialForce / 2f, maxInitialForce);
                
            rb.AddForce(randomDirection * randomForce, ForceMode.Impulse);
            
            SpawnedCubes.Add(c);
        }
    }

    private Vector3 SpawnPositionWorld(Vector3 boxBounds)
    {
        float gameHalfX = boxBounds.x / 2f; 
        float gameHalfY = boxBounds.y / 2f; 
        
        float visibleHalfX = gameHalfX - padding;
        float visibleHalfY = gameHalfY - padding;
            
        Vector3 spawnPositionLocal = Vector3.zero;
        int edge = Random.Range(0, 4);
            
        switch (edge)
        {
            case 0:
                spawnPositionLocal.x = Random.Range(-gameHalfX, -visibleHalfX);
                spawnPositionLocal.y = Random.Range(-gameHalfY, gameHalfY);
                break;
                    
            case 1:
                spawnPositionLocal.x = Random.Range(visibleHalfX, gameHalfX);
                spawnPositionLocal.y = Random.Range(-gameHalfY, gameHalfY);
                break;
                    
            case 2:
                spawnPositionLocal.x = Random.Range(-gameHalfX, gameHalfX);
                spawnPositionLocal.y = Random.Range(visibleHalfY, gameHalfY);
                break;
                    
            case 3:
                spawnPositionLocal.x = Random.Range(-gameHalfX, gameHalfX);
                spawnPositionLocal.y = Random.Range(-gameHalfY, -visibleHalfY);
                break;
        }

        spawnPositionLocal.z = 0;
            
        Vector3 spawnPositionWorld = _boxTransform.TransformPoint(spawnPositionLocal);
        return spawnPositionWorld;
    }
}