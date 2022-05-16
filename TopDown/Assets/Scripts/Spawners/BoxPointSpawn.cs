using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoxPointSpawn : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyObstacles;
    [SerializeField] private Transform _checkBetweenTarget;
    [SerializeField] private BoxFormation _formation;
    [SerializeField] private Point _prefab;
    [SerializeField] private List<Vector3> _pointsPosition;
    [SerializeField] private List<Point> _spawnedPoints;

    void Start()
    {
        _pointsPosition = _formation.EvaluatePoints().ToList();
        SpawnPoints();
    }

    void SpawnPoints()
    {
        foreach(Vector3 pointPos in _pointsPosition)
        {
            Point point = Instantiate(_prefab, pointPos, Quaternion.identity , transform);
            _spawnedPoints.Add(point);
        }
    }

    private void DeletePoints()
    {
        foreach(Point point in _spawnedPoints)
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

    public List<Point> GetAvailablePoints()
    {
        List<Point> availblePoints = new List<Point>();
        for(int i = 0; i < _spawnedPoints.Count; i++)
        {
            RaycastHit2D hit;
            Point point = _spawnedPoints[i];
            Vector3 direction = _checkBetweenTarget.transform.position - point.transform.position;
            float maxDistance = direction.magnitude;

            if(hit = Physics2D.Raycast(point.transform.position , direction , maxDistance, _enemyObstacles))
            {
                Debug.Log(hit.collider.gameObject.name);
                point.canReachPlayer = false;
                Debug.DrawRay(point.transform.position, direction, Color.red, 0.4f);
                continue;
            }
            else
            {
                Debug.DrawRay(point.transform.position, direction, Color.green, 0.4f);
            }

            point.canReachPlayer = true;
            availblePoints.Add(point);
        }
        return availblePoints;
    }
}
