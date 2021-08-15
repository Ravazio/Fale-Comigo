using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    public float speed;
    private bool canMove;
    private Rigidbody2D theRB2D;

    private Animator theAnimator;

    private GameObject interactableIcon;
    public bool canInteract = true;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

        if (canInteract)
        {
            interactableIcon = GameObject.FindGameObjectWithTag("InteractableIcon");
            interactableIcon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;
        }

        MovePlayer();

        if (canInteract)
        {
            interactableIcon.transform.position = new Vector2(transform.position.x, transform.position.y + 3f);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckInteraction();
        }
    }

    void MovePlayer()
    {
        if (canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);

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
        }
    }
    public void OpenInteractableIcon()
    {
        interactableIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactableIcon.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.isInteractable())
                {
                    rc.Interact();
                    return;
                }
            }
        }
    }
}