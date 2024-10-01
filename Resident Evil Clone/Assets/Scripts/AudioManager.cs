using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] public AudioClip zombieDamage;
    
    public static AudioManager instance;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
