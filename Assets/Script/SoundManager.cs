using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip looseSound;

    private float pitch;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnHitBrick(float brickPoint)
    {
        //fonction affine y= ax + b
        pitch = 0.17f * brickPoint + 1.33f;
        audioSource.pitch = pitch;
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
