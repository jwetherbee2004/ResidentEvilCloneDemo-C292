using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour, IPickupable
{
    [SerializeField] private GameObject magPrefab;
    [SerializeField] private int ammoCount;
    [SerializeField] private int ammoCapacity;
    [SerializeField] private string magType;
    public int AmmoCount {get => ammoCount; set => ammoCount = value;}

    public int AmmoCapacity {get => ammoCapacity; set => ammoCapacity = value;}

    public string MagType {get => magType; set => magType = value;}

    public void OnPickup(PlayerController player)
    {
        player.CurrentMag = Instantiate(this);
        Destroy(gameObject);
    }

    public void OnDrop()
    {
        GameObject mag = Instantiate(magPrefab, transform.position, transform.rotation);
    }

}
