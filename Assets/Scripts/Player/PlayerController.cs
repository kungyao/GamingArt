using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator _animator;
    public AudioSource _fireSound;
    public ParticleSystem _fireAnim;
    public int bulletsPerMag = 30;
    public int bulletsLeft;
    public float fireRate = 0.1f;

    float fireTimer=  0;

    void Update()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && bulletsPerMag != 30) 
        {
            bulletsPerMag = 30;
            _animator.SetTrigger("Reload");
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        if (fireTimer < fireRate || bulletsPerMag <= 0) return;
        bulletsPerMag--;
        fireTimer = 0;
        _fireSound.time = 0.2f;
        _fireSound.Play();
        _fireAnim.Play();
        //_fireSound.Play();
        _animator.SetTrigger("Fire");
    }
}
