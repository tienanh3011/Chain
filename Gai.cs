using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gai : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.SetActive(false);
            var player = collision.gameObject.GetComponent<Player>();

            player.HP -= 10;
            if (player.HP <= 0)
            {
                player.isDead = true;
            }
        }
    }

}
