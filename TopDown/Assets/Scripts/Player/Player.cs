using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Camera mainCamera { get; private set; }
    [field: SerializeField] public PlayerInput input { get; private set; }
    [field: SerializeField] public PlayerMovement movement { get; private set; }

    internal Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         
    }
}
