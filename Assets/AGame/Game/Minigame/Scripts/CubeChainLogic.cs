using System;
using System.Collections.Generic;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

public class CubeChainLogic : MonoBehaviour
{
    private class Link
    {
        public Cube A;
        public Cube B;
    }
    
    
    [SerializeField] private LineConnector _lineConnectorPrefab;
    [Inject] IWindowService _windowService;
    
    private CubeSpawner _cubeSpawner;
    private int _currentId = 0;
    private Link _currentLink = null;
    private List<Link> _links = new List<Link>();


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
                cube.Error();
                GameOverFailed();
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
                Link previousLink = _currentLink;
                _currentLink = new Link();
                _currentLink.A = cube;

                if (previousLink != null)
                {
                    LineConnector line = Instantiate(_lineConnectorPrefab);
                    line.SetTargets(previousLink.B.transform, _currentLink.A.transform);
                }
            }
            else
            {
                _currentLink.B = cube;
                _links.Add(_currentLink);
                LineConnector line = Instantiate(_lineConnectorPrefab);
                line.SetTargets(_currentLink.A.transform, _currentLink.B.transform);
            }

            _currentId++;
            cube.Linked();
            CheckGameOver();
        }
        else
        {
            cube.LinkFailed();
        }
    }

    private void CheckGameOver()
    {
        if (_currentId == _cubeSpawner.numberOfCubes)
        {
            GameOverSuccess();
        }
    }

    private void GameOverSuccess()
    {
        _windowService.Open(WindowId.Success);
    }
    
    private void GameOverFailed()
    {
        _windowService.Open(WindowId.Failed);
    }
}