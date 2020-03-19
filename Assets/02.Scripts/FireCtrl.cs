using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct PlayerSfx
{
    public AudioClip[] fire;
    public AudioClip[] reload;
}
public class FireCtrl : MonoBehaviour
{
    public enum WeaponType
    {
        RIFLE=0,SHOTGUN
    }
    public WeaponType currWeapon = WeaponType.RIFLE;
    public GameObject bullet;
    public Transform firepos;
    public ParticleSystem cartridge;
    private ParticleSystem muzzleFlash;

    private AudioSource _audio;

    public PlayerSfx playerSfx;
    void Start()
    {
        muzzleFlash = firepos.GetComponentInChildren<ParticleSystem>();
        _audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
            FireSfx();
        }
    }
    void Fire()
    {
        Instantiate(bullet, firepos.position, firepos.rotation);
        cartridge.Play();
        muzzleFlash.Play();
    }
    void FireSfx()
    {
        var _sfx = playerSfx.fire[(int)currWeapon];
        _audio.PlayOneShot(_sfx, 1.0f);
    }
}
