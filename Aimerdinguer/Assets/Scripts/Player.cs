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
    public int weaponInUse = 0;
    public float weaponDamage = 0;
    public float weaponRange = 0;
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
        WeaponNew(0);

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
        if (Input.GetKey(KeyCode.Mouse0) && !weaponReloading)
        {
            WeaponShoot();
        }
        if (Input.GetKey(KeyCode.R)) {
            WeaponReload();
        }


    }

    public void WeaponNew(int newWeapon)
    {
        switch (newWeapon)
        {
            case 0:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 0.2f;
                weaponReloadMaxTime = 2;
                break;
            case 1:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 2:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 3:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
                weaponMaxBullets = 30;
                weaponBullets = 30;
                weaponFireRate = 5;
                weaponReloadMaxTime = 5;
                break;
            case 4:
                weaponInUse = 0;
                weaponDamage = 1;
                weaponRange = 30;
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

            Instantiate(playerProyectile, new Vector3(playerCannon.transform.position.x, playerCannon.transform.position.y, playerCannon.transform.position.z), Quaternion.Euler(90, playerCannon.transform.rotation.y * 180, 0));
            
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




