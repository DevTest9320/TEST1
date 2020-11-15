using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private GameObject player;
    private Transform Playertrans;
    private Rigidbody2D bulletRB;
    public float bulletspeed;
    public float bulletlife;
    private int direction;

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Playertrans = player.transform;
        
    }
    void Start()
    {
        if (player.GetComponent<HeroKnight>().m_facingDirection > 0 && player.GetComponent<HeroKnight>().m_facingDirectionY == 0)
            direction = 1;
        else if (player.GetComponent<HeroKnight>().m_facingDirection < 0 && player.GetComponent<HeroKnight>().m_facingDirectionY == 0)
            direction = -1;
        else if (player.GetComponent<HeroKnight>().m_facingDirectionY > 0)
            direction = 2;
        else if (player.GetComponent<HeroKnight>().m_facingDirectionY < 0)
            direction = 3;

            switch (direction)
        {
            case -1:    //izquierda
                bulletRB.velocity = new Vector2(-bulletspeed, bulletRB.velocity.y);
                break;
            case 1:     //derecha
                bulletRB.velocity = new Vector2(bulletspeed, bulletRB.velocity.y);
                break;
            case 2:    //arriba
                bulletRB.velocity = new Vector2(bulletRB.velocity.x, -bulletspeed);
                break;

            case 3: // Abajo
                bulletRB.velocity = new Vector2(bulletRB.velocity.x, bulletspeed);
                break;
            default:

                break;


        }

            
            
        
            
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bulletlife);
    }
}
