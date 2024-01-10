using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeSpan = 5f;
    [SerializeField] int damages = 1;
    [SerializeField] float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }
    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Target _target=other.GetComponent<Target>();
        if (_target==null)return;
        _target.AddHealth(-damages);
        Debug.Log("target");
        Destroy(gameObject);
    }
}
