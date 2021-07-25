using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed = 5f;

    public Animator animator;
    public GameObject interactableIcon;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private void Start()
    {
        interactableIcon.gameObject.GetComponent<GameObject>();
        interactableIcon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckInteraction();
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
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize,0,Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
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
