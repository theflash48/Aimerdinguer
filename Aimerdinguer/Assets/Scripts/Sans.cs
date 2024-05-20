using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sans : MonoBehaviour
{
    // Variables
    // Sans Stats
    public int maxHealth;
    public int health;
    public float movementMaxCooldown;
    public float movementCooldown;

    // Imports
    public NavMeshAgent nmAgent;
    public GameObject player;
    public Transform tplayer;
    public Player sPlayer;
    public Weapon mortadela;
    public GameObject checkPoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tplayer = player.GetComponent<Transform>();
        sPlayer = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(tplayer.transform.position);
        randomMovement();
        mortadela.MortadelaShoot();
        Status();
    }

    void randomMovement()
    {
        if (movementCooldown > 0)
        {
            movementCooldown -= Time.deltaTime;
        }
        else
        {
            int child = Random.Range(0, 8);

            nmAgent.SetDestination(checkPoints.transform.GetChild(child).position);

            movementCooldown = movementMaxCooldown;
        }
    }
    
    void Status()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= other.gameObject.GetComponent<PlayerProyectile>().damage;
        }

        if (other.gameObject.CompareTag("Pellet"))
        {
            health -= other.gameObject.GetComponent<PlayerProyectile>().damage;
        }

    }
}
