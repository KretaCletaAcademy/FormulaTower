using System.Collections.Generic;
using UnityEngine;

public sealed class WayPointsMechaincs
{
    private float _speed;

    private List<Transform> _points = new List<Transform>();
    private int _pointIndex = 0;
    private Vector3 _point;
    private Vector3 _lastPosition;

    private readonly AtomicEvent<List<Transform>> _moveEvent;

    public WayPointsMechaincs(AtomicEvent<List<Transform>> moveEvent, float speed)
    {
        _moveEvent = moveEvent;
        _speed = speed;
    }

    public void OnEnable()
    {
        _moveEvent.Subscribe(StartMove);
    }


    public void OnDisable() {
        _moveEvent.Unsubscribe(StartMove);
    }

    private void StartMove(List<Transform> points)
    {
        _points = points;
        _pointIndex = 0;
        _lastPosition = Character.instance.transform.position;
    }

    public void Update()
    {
        Character player = Character.instance;
        if (_pointIndex < _points.Count)
        {
            var waypoint = _points[_pointIndex].position;
            _point = new(_lastPosition.x + waypoint.x, 0f, _lastPosition.z + waypoint.z);
            if (Vector3.Distance(player.transform.position, waypoint) > 1)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, waypoint, _speed * Time.deltaTime);
            } else
            {
                player.transform.position = waypoint;
                _pointIndex++;
                _lastPosition = waypoint;
            }
        }
    }
}


