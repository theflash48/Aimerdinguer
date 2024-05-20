using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mosca : MonoBehaviour
{
    // MoscaDatos
    public int health;
    public int maxHealth;
    public int damage;

    // Imports
    public NavMeshAgent nmAgent;
    public GameObject player;
    public Transform tplayer;
    public Player sPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tplayer = player.GetComponent<Transform>();
        sPlayer = player.GetComponent<Player>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        nmAgent.SetDestination(tplayer.position);
        Status();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            sPlayer.health -= damage;
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= other.gameObject.GetComponent<PlayerProyectile>().damage;
        }

        if (other.gameObject.CompareTag("Pellet"))
        {
            health -= other.gameObject.GetComponent<PlayerProyectile>().damage;
        }

    }

    void Status()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
