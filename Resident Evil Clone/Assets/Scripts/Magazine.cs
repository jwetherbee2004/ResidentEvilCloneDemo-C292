using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour, IPickupable
{
    [SerializeField] private int ammoCount;
    [SerializeField] private int reloadAmount;
    [SerializeField] private int ammoCapacity;
    [SerializeField] private string magType;
    public int AmmoCount {get => ammoCount; set => ammoCount = value;}

    public int AmmoCapacity {get => ammoCapacity; set => ammoCapacity = value;}

    public string MagType {get => magType; set => magType = value;}

    public int ReloadAmount {get => reloadAmount; set => reloadAmount = value;}

    public void OnPickup(PlayerController player)
    {
        player.CurrentMag = this;
        gameObject.SetActive(false);
        gameObject.transform.parent = player.transform;
    }

    public void OnDrop(Transform position)
    {
        gameObject.SetActive(true);
        transform.position = position.position;
        gameObject.transform.parent = null;
    }

    public void Reload()
    {
        if(ammoCapacity > 0){
            ammoCount = reloadAmount;
            ammoCapacity -= reloadAmount;
        }
        
    }

}
