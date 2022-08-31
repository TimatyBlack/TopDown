using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _up = KeyCode.W;
    [SerializeField] private KeyCode _down = KeyCode.S;

    public event System.Action LeftIsDown;
    public event System.Action RightIsDown;
    public event System.Action UpIsDown;
    public event System.Action DownIsDown;

    public event System.Action<Vector2> InputDirection;
    private Vector2 _inputDirection;

    private void Update()
    {
        _inputDirection = Vector2.zero;

        if (Input.GetKey(_left))
        {
            _inputDirection.x -= 1;
            LeftIsDown?.Invoke();
        }
        if (Input.GetKey(_right))
        {
            _inputDirection.x += 1;
            RightIsDown?.Invoke();
        }
        if (Input.GetKey(_up))
        {
            _inputDirection.y += 1;
            UpIsDown?.Invoke();
        }
        if (Input.GetKey(_down))
        {
            _inputDirection.y -= 1;
            DownIsDown?.Invoke();
        }

        InputDirection?.Invoke(_inputDirection);
    }

    public Vector3 GetCursorScreenToWorldPoint()
    {
        return _player.mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
