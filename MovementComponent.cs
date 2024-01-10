using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : CustomComponent
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotationSpeed = 50;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        if (playerRef == null) return;
        Vector3 _movementDirection = playerRef.Move.ReadValue<Vector3>();
        if (_movementDirection.z != 0 || _movementDirection.x != 0)
        { 
            transform.position += transform.forward * _movementDirection.z * moveSpeed * Time.deltaTime;
            transform.position += transform.right * _movementDirection.x * moveSpeed * Time.deltaTime;
        }
        
    }
    void Rotate()
    {
        if (playerRef == null) return;
        float _rotationValue=playerRef.Rotate.ReadValue<float>();
        transform.eulerAngles += transform.up *_rotationValue* rotationSpeed * Time.deltaTime ;
    }
}
