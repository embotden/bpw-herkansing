using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //states for movement animation
    private enum State { idle, patrolling, attacking, damage, dying }
    private State state = State.idle;

    public Animator animator;
    
    private Rigidbody2D rb;

    //health system
    public int maxHealth;
    public static int currentHealth;
    public static bool takedamge = false;
    public float enemyImpact = 0;
    private bool takingImpact = true;
    
    //movement
    public float speed;
    public float oldSpeed;
    public float distance;
    private bool movingLeft = true;

    //restart
    public GameObject restartSugest;
    public float restartDelay = 1f;
    bool gameHasEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = -1;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)) //Press R to restart level
        {
            Restart();
        }

        //Start movement
        if (!takedamge)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        EnemyStates();
    }

    private void OnCollisionEnter2D(Collision2D other) //Of enemy collides with border, turn around
    {
        if(other.gameObject.tag == "Border")
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }
    public void TakeDamage(int damage) //Damage
    {
        currentHealth -= damage;

        //If health is 0, enemy dies
        if (currentHealth <= 0)
        {
            Die();
            state = State.dying;
        }
        else
        {
            StartCoroutine(DamageImpact());
            state = State.damage;
        }
    }

    IEnumerator DamageImpact()
    {
        animator.SetBool("hurting", true);

        //Stop movement
        speed = 0;

        //Move up
        rb.gravityScale *= -1;

        yield return new WaitForSeconds(3f);

        takingImpact = false;

        //start animation
        animator.SetBool("hurting", false);

        //start Moving again
        speed = oldSpeed;
    }

    public void Die() //Death
    {
        speed = 0; //Stop enemy movement
        
        //Die animation
        animator.SetTrigger("Dying");

        //Disable enemy
        rb.gravityScale = 0;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //Suggest restart
        restartSugest.gameObject.SetActive(true);
    }

    private void EnemyStates()
    {
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            state = State.patrolling; //Moving
        }
        else
        {
            state = State.idle; //Idle
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            //Restart Level
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
