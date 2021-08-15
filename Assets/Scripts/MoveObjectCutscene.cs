using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectCutscene : MonoBehaviour
{
    public float speedMove;
    private Rigidbody2D theRB2D;
    private Animator theAnimator;

    public float limit;
    public float counter = 0;

    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        theRB2D = Player.GetComponent<Rigidbody2D>();
        theRB2D.velocity = new Vector2(0, 0);
        theAnimator = Player.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(counter < limit)
        {
            theRB2D.velocity = new Vector2(speedMove, theRB2D.velocity.y);

            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));

            // Se está movendo pra direita
            if (theRB2D.velocity.x > 0)
            {
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (theRB2D.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1f, 1f);
            }

            counter++;
        }
        else
        {
            theRB2D.velocity = new Vector2(0, theRB2D.velocity.y);

            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));
        }

    }
}
