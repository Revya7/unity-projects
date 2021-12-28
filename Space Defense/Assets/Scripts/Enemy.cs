using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBTWShots = 0.2f;
    [SerializeField] float maxTimeBTWShots = 3f;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] GameObject projectile;

    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] float shootSoundVolume = 0.7f;
    [SerializeField] RunVFX visualEffect;
    [SerializeField] int scoreGain = 150;
    [SerializeField] GameSession gameSession;

    void Start()
    {
        shotCounter = Random.Range(minTimeBTWShots, maxTimeBTWShots);
        gameSession = FindObjectOfType<GameSession>();
    }


    private void Fire() {
        GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        shotCounter = Random.Range(minTimeBTWShots, maxTimeBTWShots);
    }

    void Update()
    {
        shotCounter -= Time.deltaTime;  // to make it indep of frame
        if(shotCounter <= 0) {
            Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            GameObject deathViusalEffect = Instantiate(visualEffect.GetDeathVisualEffect(), gameObject.transform.position, transform.rotation) as GameObject;
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            gameSession.IncreaseScore(scoreGain);
            Destroy(deathViusalEffect, 1f);
            Destroy(gameObject);
        }
    }
}
