using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int ammoCapacity;
    [SerializeField] protected int currentAmmo;
    [SerializeField] protected float fireRate;
    [SerializeField] protected bool canFire = true;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float damage;
    [SerializeField] protected float reloadTime;

    protected virtual void Fire() { }
    protected virtual void Reload() { }
    protected virtual void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
