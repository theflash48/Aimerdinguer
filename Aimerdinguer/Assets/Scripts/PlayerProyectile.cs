using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProyectile : MonoBehaviour
{

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * 1000 * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider collision)
    {
        /*if (collision != null)
        {
            Destroy(gameObject);
        }*/
    }
}
