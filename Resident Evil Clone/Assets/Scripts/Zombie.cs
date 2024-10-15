using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float maxHealth = 1;
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        target = GameObject.Find("Player").transform;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(target.position); 
    }

    public void TakeDamage(float damage)
    {
        // AudioManager.instance.PlayOneShot(AudioManager.instance.zombieDamage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            UIManager.zombieDeath?.Invoke(10);
            Destroy(gameObject);
        }
    }
}
