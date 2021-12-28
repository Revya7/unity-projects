using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float padding = 0.7f;
    [SerializeField] int health = 250;

    [Header("Projectile")]
    [SerializeField] GameObject LaserBeam;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float fireCoolDown = 0.2f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathSoundVolume = 0.7f;

    [SerializeField] AudioClip shootSound;
    [SerializeField] float shootSoundVolume = 0.7f;
    [SerializeField] Text healthText;

    //idk
    Coroutine FiringBoomRoutine;

    //config
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start()
    {
        Camera camera = Camera.main;
        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;  // the first 0 is what we need, we dont care about rest cz .x
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;  // 1 is the end of the camera view, 0 is the start
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        UpdateHealthText();
    }


    private void UpdateHealthText() {
        if(health <= 0) { 
            healthText.GetComponent<Text>().text = "0";
        } else
        {
            healthText.GetComponent<Text>().text = health.ToString();   
        }
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            FiringBoomRoutine = StartCoroutine(FireBoomBoom());
        }

        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(FiringBoomRoutine);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer) { return; } // protection
        ProcessHit(damageDealer);
        UpdateHealthText();
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            Destroy(gameObject);
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }
    }

    IEnumerator FireBoomBoom() {
        while (true) {
            GameObject LaserShot = Instantiate(LaserBeam, transform.position, Quaternion.identity) as GameObject; // obj, vector, rotation(default)
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            LaserShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            yield return new WaitForSeconds(fireCoolDown);
        }
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;    // GetAxis return a float, if not will be transition.position.x (horiz), fps indep deltatime
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXpos, newYpos);
    }
}
