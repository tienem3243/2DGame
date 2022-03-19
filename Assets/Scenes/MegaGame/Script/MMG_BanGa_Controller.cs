using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMG_BanGa_Controller : MonoBehaviour
{
    [Header("Key setting")]
    [SerializeField]
    private KeyCode[] _moveLeft = { KeyCode.A, KeyCode.LeftArrow };
    [SerializeField]
    private KeyCode[] _moveRight = { KeyCode.D, KeyCode.RightArrow };

    [Header("Player Infor")]
    [SerializeField]
    private float _movementSpeed = 10;
    private Rigidbody2D _rigidbody2D;

    Vector2 movement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //pause and resume
        movement.x = Input.GetAxis("Horizontal");

        // transform.position += new Vector3(movement, 0, 0) * _movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position +
        (movement * _movementSpeed * Time.fixedDeltaTime));
    }

}
