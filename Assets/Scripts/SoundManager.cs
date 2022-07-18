using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager _SOUND_MANAGER;



    public AudioSource audioSource2D;
    [Header("Music")]
    [SerializeField]
    private AudioSource musicAudioSource;
    [SerializeField]
    private AudioClip musicClip;

    [Header("Clips")]

    [SerializeField]
    private AudioClip knifePickUp;
    [SerializeField]
    private AudioClip knifeCutting;
    [SerializeField]
    private AudioClip stoveNoFood;
    [SerializeField]
    private AudioClip stoveFood;
    [SerializeField]
    private AudioClip platePickUp;
    [SerializeField]
    private AudioClip plateServed;

    // Start is called before the first frame update

    private void Awake()
    {
        if (SoundManager._SOUND_MANAGER != null)
        {
            Destroy(gameObject);

        }
        else
        {
            _SOUND_MANAGER = this;

        }
        audioSource2D = GetComponent<AudioSource>();




    }


    void Start()
    {
        musicAudioSource.clip = musicClip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KnifePickUp(AudioSource _currentAS)
    {

        _currentAS.PlayOneShot(knifePickUp);
    }
    public void PlatePickUp(AudioSource _currentAS)
    {

        _currentAS.PlayOneShot(platePickUp);
    }
    public void PlateServed(AudioSource _currentAS)
    {

        _currentAS.PlayOneShot(plateServed);
    }

}
