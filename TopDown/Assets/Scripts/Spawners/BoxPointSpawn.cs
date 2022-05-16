using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoxPointSpawn : MonoBehaviour
{
    [SerializeField] private BoxFormation _formation;
    [SerializeField] private Transform _prefab;
    [SerializeField] private List<Vector3> _pointsPosition;
    [SerializeField] private List<Transform> _spawnedPoints;

    void Start()
    {
        _pointsPosition = _formation.EvaluatePoints().ToList();
        SpawnPoints();
    }

    private void FixedUpdate()
    {
        UpdatePointsPos();
    }

    void SpawnPoints()
    {
        foreach(Vector3 pointPos in _pointsPosition)
        {
            Transform point = Instantiate(_prefab, pointPos, Quaternion.identity , transform);
            _spawnedPoints.Add(point);
        }
    }

    private void DeletePoints()
    {
        foreach(Transform point in _spawnedPoints)
        {
            _spawnedPoints.Remove(point);
            Destroy(point.gameObject);
        }
    }

    private void UpdatePointsPos()
    {
        _pointsPosition = _formation.EvaluatePoints().ToList();
        for (int i = 0; i < _pointsPosition.Count; i++)
        {
            _spawnedPoints[i].transform.position = _pointsPosition[i];
        }
    }
}
