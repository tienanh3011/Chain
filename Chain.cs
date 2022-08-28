using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 10f;
    bool isRevert = false;
    private Vector2 origin;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        target = new Vector2(origin.x + distance, origin.y);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (!isRevert)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if (Vector2.Distance(transform.position, target) < 0.1f)
            {
                isRevert = true;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, origin, step);
            if (Vector2.Distance(transform.position, origin) < 0.1f)
            {
                isRevert = false;
            }
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.SetActive(false);
            var player = collision.gameObject.GetComponent<Player>();
            
            player.HP -=10;
            if (player.HP <= 0)
            {
                player.isDead = true;
                GameHelper.instance.SoundController.PlaySound(SoundName.Death, false);
            }
            else

            {
                GameHelper.instance.SoundController.PlaySound(SoundName.Hurt, false);
            }
        }
    }
    
}
