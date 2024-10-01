using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Fire()
    {
        if(currentMag == null)
        {
            Debug.Log("No Mag");
            return;
        }
        if(currentMag.AmmoCount > 0 && canFire)
        {
            Debug.Log("Bang!");
            currentMag.AmmoCount--;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, 100))
            {
                Debug.DrawRay(firePoint.position, firePoint.forward * hit.distance, Color.red, 2f);
                if(hit.transform.CompareTag("Zombie"))
                {
                    hit.transform.GetComponent<Zombie>().TakeDamage(damage);
                }
            }
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }

    protected override void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        canFire = false;

        yield return new WaitForSeconds(reloadTime);

        canFire = true;
        currentMag.Reload();
    }
}
