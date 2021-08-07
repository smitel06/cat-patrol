using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShake : MonoBehaviour
{
    //a behaviour for shaking the screen
    Transform camTransform;
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.04f;
    float dampingSpeed = 1.0f;
    Vector3 initialPosition;
    //gamemanager so we can call the script
    public GameObject gameManager;
    //sound things 
    public AudioClip background;
    public AudioClip frenzy;
    public AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        if(camTransform == null)
        {
            camTransform = gameObject.transform;
        }

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void OnEnable()
    {
        initialPosition = camTransform.localPosition;
    }

    private void Update()
    {
        if(shakeDuration > 0)
        {
            gameManager.GetComponent<gameManager>().cameraShake = true;
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;

            if (audioSource.clip == background)
            {
                //change sound
                audioSource.clip = frenzy;
                audioSource.time = 5.0f;
                audioSource.Play();
                
            }
        }
        else
        {
            if (audioSource.clip == frenzy)
            {
                audioSource.clip = background;
                audioSource.Play();
            }

            gameManager.GetComponent<gameManager>().cameraShake = false;
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
}
