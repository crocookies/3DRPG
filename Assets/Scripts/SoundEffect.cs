using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField]
    private AudioClip jump;
    [SerializeField]
    private AudioClip attack;
    [SerializeField]
    private AudioClip magic;
    [SerializeField]
    private AudioClip dash;
    [SerializeField]
    private AudioClip hit;
    [SerializeField]
    private AudioClip die;

    [SerializeField]
    private AudioClip monsterHit;
    [SerializeField]
    private AudioClip monsterDie;

    [SerializeField]
    private AudioClip shop;
    [SerializeField]
    private AudioClip item;

    AudioSource audioSource;

    public static SoundEffect instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void Attack()
    {
        audioSource.PlayOneShot(attack);
    }

    public void Magic()
    {
        audioSource.PlayOneShot(magic);
    }

    public void Dash()
    {
        audioSource.PlayOneShot(dash);
    }

    public void Hit()
    {
        audioSource.PlayOneShot(hit);
    }

    public void Die()
    {
        audioSource.PlayOneShot(die);
    }

    public void MonsterHit()
    {
        audioSource.PlayOneShot(monsterHit);
    }

    public void MonsterDie()
    {
        audioSource.PlayOneShot(monsterDie);
    }

    public void Shop()
    {
        audioSource.PlayOneShot(shop);
    }

    public void Item()
    {
        audioSource.PlayOneShot(item);
    }
}
