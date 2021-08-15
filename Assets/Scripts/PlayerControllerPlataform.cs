using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerPlataform : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool canMove;
    private Rigidbody2D theRB2D;

    // Está no chão ou não
    public bool grounded;
    // O que é considerado chão
    public LayerMask whatIsGround;
    // Posição
    public Transform groundChecker;
    public float groundCheckerRadius;

    // O quão alto podemos subir
    public float airTime;
    // Guarda quanto tempo vamos permanecerno ar
    public float airTimeCounter;

    private Animator theAnimator;

    public int pickUpsNeeded;
    public int pickUpsGotIt;
    public Text pickUpsNeededText;
    public Text pickUpsGotItText;

    public LevelLoaderScript levelLoader;

    public bool IsLastLevel;

    public AudioSource jumpSound;
    public AudioSource pickUpSound;

    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();
        airTimeCounter = airTime;

        //pickUpsGotIt = 0;
        pickUpsNeededText.text = pickUpsNeeded.ToString();
        pickUpsGotItText.text = pickUpsGotIt.ToString();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;
        }

        MovePlayer();
        Jump();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);
    }

    void MovePlayer()
    {
        if(canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);

            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));

            // Se está movendo pra direita
            if(theRB2D.velocity.x > 0)
            {
                transform.localScale = new Vector2(1f,1f);
            }else if (theRB2D.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1f, 1f);
            }
        }
    }

    void Jump()
    {
        if(grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpSound();
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
            }
        }

        // Get Key - Registra todo frame que o botão está pressionado
        if (Input.GetKey(KeyCode.Space))
        {
            // timer - o quão alto podemos pular
            // O que está acontecendo é, enquanto eu manter a tecla pressionada, ele vai continuar subindo, até airTimeCounter zerar
            if (airTimeCounter > 0) {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
                airTimeCounter -= Time.deltaTime;
            }
        }

        // Get Key Up - Registra quando nós soltamos o botão
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // timer - quando o pulo deve parar
            airTimeCounter = 0;
        }

        if (grounded)
        {
            airTimeCounter = airTime;
        }

        theAnimator.SetBool("Grounded", grounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            if (pickUpsGotIt < pickUpsNeeded)
            {
                PickUpSound();
                pickUpsGotIt += 1;
                pickUpsGotItText.text = pickUpsGotIt.ToString();
                Debug.Log("PickUps = " + pickUpsGotIt);
                if (IsLastLevel)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Soundtrack"));
                    //Destroy(GameObject.Find("PickUpsScore"));
                }
                levelLoader.LoadNextLevel();
            }
        }
    }
    public void JumpSound()
    {
        StartCoroutine(JumpSoundRoutine());
    }

    IEnumerator JumpSoundRoutine()
    {
        jumpSound.Play();
        yield return null;
    }

    public void PickUpSound()
    {
        StartCoroutine(PickUpSoundRoutine());
    }

    IEnumerator PickUpSoundRoutine()
    {
        pickUpSound.Play();
        yield return null;
    }
}
