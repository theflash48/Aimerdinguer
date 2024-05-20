using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool holdClick;
    public float bulletDispersion;
    public int inUse;
    public int maxBullets;
    public int bullets;
    public float fireRate;
    public float fireRateCooldown;
    public float reloadMaxTime;
    public float reloadTime;
    public bool reloading;

    public GameObject bullet;
    public GameObject pellet;
    public GameObject mortadela;
    public GameObject dollar;
    public GameObject shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        bullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        Timers();
    }

    // Player Weapons
    public void PistolShoot()
    {
        if (fireRateCooldown <= 0 && bullets > 0 && !reloading)
        {
            fireRateCooldown = fireRate;
            bullets--;

            Instantiate(bullet, shootPoint.transform.position, transform.rotation);
            
        }
    }

    public void ShotgunShoot()
    {
        if (fireRateCooldown <= 0 && bullets > 0 && !reloading)
        {
            fireRateCooldown = fireRate;
            bullets--;

            
            for (int i = 0; i < 15; i++)
            {
                Quaternion dispersion = Quaternion.Euler(Random.Range(-bulletDispersion, bulletDispersion),
                                                Random.Range(-bulletDispersion, bulletDispersion),
                                                Random.Range(-bulletDispersion, bulletDispersion));
                Instantiate(pellet, shootPoint.transform.position, transform.rotation * dispersion);

            }
            

        }
    }

    // Enemies Weapones
    public void MortadelaShoot()
    {
        if (fireRateCooldown <= 0 && bullets > 0 && !reloading)
        {
            fireRateCooldown = fireRate;
            bullets--;

            Instantiate(mortadela, shootPoint.transform.position, transform.rotation);

        }
    }
    public void DollarShoot()
    {
        Debug.Log(1);
        if (fireRateCooldown <= 0 && bullets > 0 && !reloading)
        {
            Debug.Log(2);
            fireRateCooldown = fireRate;
            bullets--;

            Instantiate(dollar, shootPoint.transform.position, transform.rotation);

        }
    }


    public void Reload()
    {

        if (!reloading && maxBullets != bullets)
        {
            reloading = true;
            reloadTime = reloadMaxTime;
        }

    }

    public void Timers()
    {

        if (reloading)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0f)
            {
                reloading = false;
            }
            if (reloading == false)
            {
                bullets = maxBullets;
            }
        }

        if (fireRateCooldown > 0)
        {
            fireRateCooldown -= Time.deltaTime;
        }

    }




}
