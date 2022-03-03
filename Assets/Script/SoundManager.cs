using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip brickImpact;
    [SerializeField] private AudioClip wallImpact;
    [SerializeField] private AudioClip deadZone;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnHitBrick()
    {
        audioSource.PlayOneShot(brickImpact);
    }

    public void OnHitWall()
    {
        audioSource.PlayOneShot(wallImpact);
    }

    public void OnHitDeadZone()
    {
        audioSource.PlayOneShot(deadZone);
    }
}
