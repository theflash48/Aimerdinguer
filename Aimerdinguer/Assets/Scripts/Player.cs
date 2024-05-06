using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Inputs and Camera
    float inputCameraX;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    bool lockedCursor = true;

    //Player Data
    public int maxHealth = 100;
    public int health = 100;
    public float speed = 5;
    
    //Weapon Data
    public int weaponInUse;
    public int weaponDamage;
    public int weaponRange;
    public int weaponMaxBullets;
    public int weaponBullets;
    public int weaponReloadMaxTime;
    public float weaponReloadTime = 0f;
    public bool weaponReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        MoveAndCamera();
        WeaponReload();
        if (!weaponReloading)
        {
            WeaponShoot();
        }
    }

    public void MoveAndCamera()
    {
        inputCameraX = Input.GetAxis("Mouse X") * mouseSensitivity;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up * inputCameraX);
    }

    public void WeaponNew(int newWeapon)
    {
        switch (newWeapon)
        {
            case 0:
                weaponInUse = 0;
                weaponDamage = 0;
                weaponRange = 0;
                weaponMaxBullets = 0;
                weaponBullets = 0;
                weaponReloadTime = 0;
                weaponReloading = false;
                break;
            case 1:
                weaponInUse = 0;
                weaponDamage = 0;
                weaponRange = 0;
                weaponMaxBullets = 0;
                weaponBullets = 0;
                weaponReloadTime = 0;
                weaponReloading = false;
                break;
            case 2:
                weaponInUse = 0;
                weaponDamage = 0;
                weaponRange = 0;
                weaponMaxBullets = 0;
                weaponBullets = 0;
                weaponReloadTime = 0;
                weaponReloading = false;
                break;
            case 3:
                weaponInUse = 0;
                weaponDamage = 0;
                weaponRange = 0;
                weaponMaxBullets = 0;
                weaponBullets = 0;
                weaponReloadTime = 0;
                weaponReloading = false;
                break;
            case 4:
                weaponInUse = 0;
                weaponDamage = 0;
                weaponRange = 0;
                weaponMaxBullets = 0;
                weaponBullets = 0;
                weaponReloadTime = 0;
                weaponReloading = false;
                break;

        }
    }

    public void WeaponReload()
    {
        if (Input.GetKey(KeyCode.R))
        {
            weaponReloading = true;
            weaponReloadTime = weaponReloadMaxTime;
        }
        
        if (weaponReloading == true)
        {
            weaponReloadTime -= Time.deltaTime;
            if (weaponReloadTime <= 0f)
            {
                weaponReloading = false;
            }
        }
    }
    public void WeaponShoot()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
