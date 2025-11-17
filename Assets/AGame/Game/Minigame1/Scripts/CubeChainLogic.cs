using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeChainLogic : MonoBehaviour
{
    private class Link
    {
        public Cube A;
        public Cube B;
    }
    
    
    private CubeSpawner _cubeSpawner;

    private int _currentId = 0;
    
    private List<Link> _links = new List<Link>();
    
    private Link _currentLink = null;


    public void Initialize(CubeSpawner spawner)
    {
        _cubeSpawner = spawner;
        SubscribeCubes();
    }

    private void SubscribeCubes()
    {
        foreach (Cube cube in _cubeSpawner.SpawnedCubes)
        {
            cube.OnClick.AddListener(OnCubeClick);
        }
    }

    private void OnCubeClick(CubeType type, Cube cube)
    {
        switch (type)
        {
            case CubeType.Cube:
                CheckChain(cube);
                break;
            
            case CubeType.ErrorCube:
                GameOverLoose();
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private void CheckChain(Cube cube)
    {
        if (_currentId == cube.Id)
        {

            if (_currentId % 2 == 0)
            {
                _currentLink = new Link();
                _currentLink.A = cube;
                Debug.Log(" cube chain " + _currentId);
                
                //Візуальний еффект, що зараз цей куб обраний
            }
            else
            {
                _currentLink.B = cube;
                _links.Add(_currentLink);
                
                Debug.Log(" cube chain " + _currentId);
                //Візуальний еффект створення лінії
            }
            
            
            _currentId++;
            if (_currentId == _cubeSpawner.numberOfCubes)
            {
                GameOverWin();
            }
            
        }
        else
        {
            // //Візуальний еффект еррора
            Debug.Log("Error cube chain");
        }
    }
    
    
    private void GameOverWin()
    {
        Debug.Log("Game Over Win");
    }
    
    private void GameOverLoose()
    {
        Debug.Log("Game Over Loose");
    }
}