using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomComponent : MonoBehaviour
{
    [SerializeField] protected Player playerRef = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerRef= GetComponent<Player>();
        if (playerRef == null) 
        {
            Debug.Log("Failed to find player component");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
