using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    int AmmoCount {get; set;}

    int AmmoCapacity {get; set;}

    public string MagType {get; set;}

    public void OnPickup(PlayerController player);

    public void OnDrop(Transform position);
}
