using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackComponent : CustomComponent
{
    [SerializeField] Projectile toSpawn = null;
    [SerializeField] float currentTime = 0;
    [SerializeField] float maxTime = 1;
    [SerializeField] bool canAttack = true;
    [SerializeField] bool isAttacking = false;
    [SerializeField] Vector3 spawnPosition = Vector3.zero;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = IncreaseTime(currentTime, maxTime); 
         AutoAttack();
    }
    public void Attack(InputAction .CallbackContext _context)
    {
        Debug.Log("attack");
        if (!canAttack) return;
        SpawnProjectile();
        canAttack = false;
    }
    void AutoAttack()
    {
        if (!isAttacking || !canAttack) return;
        SpawnProjectile();
        canAttack = false;
        
    }
    void SpawnProjectile()
    {
        spawnPosition = transform.position + transform.forward * 2;
        Projectile _projectile = Instantiate(toSpawn,spawnPosition,transform.rotation);
    }
    float IncreaseTime(float _current,float _max)
    {
        if (canAttack) return _current;
        _current += Time.deltaTime;
        if (_current >= maxTime)
        {
            _current = 0;
            canAttack = true;
        }
        return _current;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnPosition, .5f);
        Gizmos.color = Color.white;
    }
    public void SetIsAttacking(InputAction.CallbackContext _context)
    {
        isAttacking=_context.ReadValueAsButton();
    }
}
