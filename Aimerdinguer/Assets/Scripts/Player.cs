using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{

    //Inputs and Camera
    float inputCameraX = 0f;
    public float mouseSensitivity = 2f;

    //bool lockedCursor = true;

    //Player Data
    public int maxHealth = 100;
    public int health = 100;
    public float playerSpeed = 5;
    public int weaponInUse;
    public GameObject shotgun;
    public GameObject pistol;
    public Weapon scriptShotgun;
    public Weapon scriptPistol;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (weaponInUse == 0)
        {
            pistol.SetActive(true);
            shotgun.SetActive(false);
        }
        else if (weaponInUse == 1)
        {
            pistol.SetActive(false);
            shotgun.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Status();
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
        
        switch (weaponInUse)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    scriptPistol.PistolShoot();
                }
                break;

            case 1:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    scriptShotgun.ShotgunShoot();
                }
                break;
        }
                
        if (Input.GetKeyDown(KeyCode.R)) {
            //weaponReload();
            switch (weaponInUse)
            {
                case 0:
                    scriptPistol.Reload();
                    break;

                case 1:
                    scriptShotgun.Reload();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !scriptPistol.reloading && !scriptShotgun.reloading)
        {
            if (weaponInUse == 0)
            {
                weaponInUse = 1;
                pistol.SetActive(false);
                shotgun.SetActive(true);
            }
            else if (weaponInUse == 1)
            {
                weaponInUse = 0;
                pistol.SetActive(true);
                shotgun.SetActive(false);
            }
        }
    }
    void Status()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Mortadela"))
        {
            //Destroy(other.gameObject);
            health -= other.gameObject.GetComponent<PlayerProyectile>().damage;
            Debug.Log(other.gameObject.GetComponent<PlayerProyectile>().damage);
        }
        if (other.gameObject.CompareTag("Dollar"))
        {
            //Destroy(other.gameObject);
            health -= other.gameObject.GetComponent<PlayerProyectile>().damage;
            Debug.Log(other.gameObject.GetComponent<PlayerProyectile>().damage);
        }

    }
}