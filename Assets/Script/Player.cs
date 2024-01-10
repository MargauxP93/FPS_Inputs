using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AttackComponent),typeof(MovementComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] AttackComponent attack = null;
    [SerializeField] MovementComponent movement = null;

    [SerializeField] FPSInputs controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction fire = null;
    [SerializeField] InputAction autoFire = null;

    public InputAction Move => move;
    public InputAction Rotate => rotate;
    public InputAction Fire => fire;
    public InputAction AutoFire => autoFire;

    private void Awake()
    {
        controls = new FPSInputs();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        move = controls.FPS.Movement;
        move.Enable();
        rotate = controls.FPS.Rotate;
        rotate.Enable();
        fire = controls.FPS.Fire;
        fire.Enable();  
        autoFire= controls.FPS.AutoFire;
        autoFire.Enable();
        autoFire.performed += attack.SetIsAttacking;
    }

    private void OnDisable()
    {
       move.Disable();
       rotate.Disable();
       fire.Disable();
       autoFire.Disable();
    }
}
