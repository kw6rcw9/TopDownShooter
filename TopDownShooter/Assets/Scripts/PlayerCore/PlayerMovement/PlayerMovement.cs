using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 1;
    private Vector3 _direction;
    private Vector3 _moveTo;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        MovePlayer(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    public void MovePlayer(float x, float y)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + new Vector2(x, y) * _speed * Time.fixedDeltaTime);
    }
    

    void Update()
    {
        _moveTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = _moveTo - transform.position;
        _direction.Normalize();
        LookAtPoint();
    }
    private void LookAtPoint()
    {
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _rigidbody2D.rotation = angle;
    }
}
