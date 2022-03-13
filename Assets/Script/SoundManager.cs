using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip looseSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnHitBrick(float brickPoint)
    {
        if (brickPoint == 1)
        {
            audioSource.pitch = 1.5f;
        }
        else if (brickPoint == 4)
        {
            audioSource.pitch = 2f;
        }
        else if (brickPoint == 7)
        {
            audioSource.pitch = 2.5f;
        }

        audioSource.PlayOneShot(hitSound);
    }
    public void OnHitPaddle()
    {
        audioSource.pitch = 0.5f;
        audioSource.PlayOneShot(hitSound);
    }
    public void OnHitWall()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(hitSound);
    }

    public void OnHitDeadZone()
    {
        audioSource.PlayOneShot(looseSound);
    }
}
