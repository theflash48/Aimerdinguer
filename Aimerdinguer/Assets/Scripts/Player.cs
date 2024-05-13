using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //Inputs and Camera
    float inputCameraX = 0f;
    public float mouseSensitivity = 2f;

    bool lockedCursor = true;

    //Player Data
    public int playerMaxHealth = 100;
    public int playerHealth = 100;
    public float playerSpeed = 5;
    public GameObject playerCannon;

    //Weapon Data
    public bool weaponHoldClick = false;
    public float weaponBulletDispersion = 0;
    public int weaponInUse = 0;
    public float weaponDamage = 0;
    public int weaponMaxBullets = 0;
    public int weaponBullets = 0;
    public float weaponFireRate = 0;
    public float weaponFireRateCooldown = 0;
    public float weaponReloadMaxTime = 0;
    public float weaponReloadTime = 0f;
    public bool weaponReloading = false;
    public GameObject playerProyectile;

    //GUI
    public TMP_Text guiHealthAmount;
    public TMP_Text guiAmmoAmount;
    public TMP_Text guiReloadTime;

    //Pablo Prueba
    public float vertical, horizontal;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        WeaponNew(1);

    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        WeaponTimers();
        GuiUpdate();
        Debug.Log(transform.rotation.y*180);
    }

    public void Inputs()
    {

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        //Camera
        inputCameraX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * inputCameraX);

        //Weapon Management
        if(weaponHoldClick == true && !weaponReloading)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                WeaponShoot();
            }
        }
        else if (!weaponReloading)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                WeaponShoot();
            }
        }
        

        

        if (Input.GetKey(KeyCode.R)) {
            WeaponReload();
        }


    }

    public void WeaponNew(int newWeapon)
    {
        switch (newWeapon)
        {
            case 0: // Pistola Inicial
                weaponHoldClick = false;
                weaponBulletDispersion = 0;
                weaponInUse = 0;
                weaponDamage = 20;
                weaponMaxBullets = 15;
                weaponBullets = 15;
                weaponFireRate = 0.2f;
                weaponReloadMaxTime = 2;
                break;
            case 1: // Escopeta Corredera
                weaponHoldClick = false;
                weaponBulletDispersion = 15;
                weaponInUse = 1;
                weaponDamage = 1;
                weaponMaxBullets = 8;
                weaponBullets = 7;
                weaponFireRate = 0.8f;
                weaponReloadMaxTime = 3;
                break;
            case 2: // Minigun
                weaponHoldClick = true;
                weaponBulletDispersion = 5;
                weaponInUse = 2;
                weaponDamage = 1;
                weaponMaxBullets = 100;
                weaponBullets = 100;
                weaponFireRate = 0.05f;
                weaponReloadMaxTime = 3;
                break;
            case 3: //
                weaponHoldClick = true;
                weaponBulletDispersion = 0;
                weaponInUse = 3;
                weaponDamage = 1;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 4: //
                weaponHoldClick = true;
                weaponBulletDispersion = 0;
                weaponInUse = 4;
                weaponDamage = 1;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
        }
        weaponReloading = false;
    }

    public void WeaponShoot()
    {
        if (weaponFireRateCooldown <= 0 && weaponBullets > 0)
        {
            weaponFireRateCooldown = weaponFireRate;
            weaponBullets--;
            
            if(weaponInUse == 1)
            {
                for (int i = 0; i < 15; i++)
                {
                    Quaternion dispersion = Quaternion.Euler(Random.Range(-weaponBulletDispersion, weaponBulletDispersion),
                                                  Random.Range(-weaponBulletDispersion, weaponBulletDispersion),
                                                  Random.Range(-weaponBulletDispersion, weaponBulletDispersion));
                    Instantiate(playerProyectile, playerCannon.transform.position, transform.rotation * dispersion);

                }
            }
            else
            {
                Quaternion dispersion = Quaternion.Euler(Random.Range(-weaponBulletDispersion, weaponBulletDispersion),
                                                  Random.Range(-weaponBulletDispersion, weaponBulletDispersion),
                                                  Random.Range(-weaponBulletDispersion, weaponBulletDispersion));
                Instantiate(playerProyectile, playerCannon.transform.position, transform.rotation * dispersion);
            }
            
        }
    }
    public void WeaponReload()
    {

        if (!weaponReloading)
        {
            weaponReloading = true;
            weaponReloadTime = weaponReloadMaxTime;
        }

    }

    public void WeaponTimers()
    {

        if (weaponReloading)
        {
            weaponReloadTime -= Time.deltaTime;
            if (weaponReloadTime <= 0f)
            {
                weaponReloading = false;
            }
            if (weaponReloading == false)
            {
                weaponBullets = weaponMaxBullets;
            }
        }
        if (weaponFireRateCooldown > 0)
        {
            weaponFireRateCooldown -= Time.deltaTime;
        }

    }

    public void GuiUpdate()
    {
        if (weaponReloadTime <= 0f)
        {
            guiReloadTime.text = "";
        }
        else
        { 
            guiReloadTime.text = "Reloading: " + weaponReloadTime.ToString("F" + 2);
        }
    
        guiAmmoAmount.text = weaponBullets.ToString();
        guiHealthAmount.text = playerHealth.ToString();
    }

    
}




