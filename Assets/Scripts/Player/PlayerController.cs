using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour {

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
  
    [Header("UI & References")]
    public GameObject row;
    public GameObject menu;
    public GameObject stats;
    public GameObject controllerMobile;
    public ParticleSystem dust;

    [Header("Combat Settings")]
    public int damagePatrols = 25;
    private float attackRate = 0.6f;
    private float nextAttackTime = 0.5f;

    // State Variables
    private bool canJump;
    private bool canDoubleJump;
    private bool facingLeft = false;
    private bool facingRight = false;
    private bool isDead = false;

    // Cached Components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PlayerControllerUP playerControllerUp;
    private Stats playerStats;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerControllerUp = GetComponentInChildren<PlayerControllerUP>();
        playerStats = GetComponentInChildren<Stats>();
    }

    private void Update() {
        if (isDead || (controllerMobile != null && controllerMobile.activeSelf)) 
            return;

        HandleMenuInput();
        HandleJumpInput();
        HandleMovementInput();
    }

    private void HandleMenuInput() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menu != null && stats != null) {
                bool isMenuActive = menu.activeSelf;
                menu.SetActive(!isMenuActive);
                stats.SetActive(isMenuActive);
                Time.timeScale = isMenuActive ? 1f : 0f;
            }
        }
    }

    private void HandleJumpInput() {
        if (playerControllerUp != null) {
            canJump = playerControllerUp.getJump();
            canDoubleJump = playerControllerUp.getDoubleJump();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canJump) {
                PerformJump();
                if (playerControllerUp != null) playerControllerUp.setJump(false);
            } else if (canDoubleJump) {
                PerformJump();
                if (playerControllerUp != null) playerControllerUp.setDoubleJump(false);
                canDoubleJump = false;
            }
        }
    }

    private void PerformJump() {
        CreateDust();
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    private void HandleMovementInput() {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A)) {
            moveDirection = -1f;
        } else if (Input.GetKey(KeyCode.D)) {
            moveDirection = 1f;
        }

        if (moveDirection != 0f) {
            CreateDust();
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
            anim.SetBool("moving", true);
            
            bool isMovingLeft = moveDirection < 0;
            spriteRenderer.flipX = isMovingLeft;
            HandleFacingDirection(isMovingLeft);
        } else {
            anim.SetBool("moving", false);
        }
    }

    private void HandleFacingDirection(bool isMovingLeft) {
        if (isMovingLeft) {
            facingLeft = true;
            if (facingRight && row != null) {
                row.transform.Rotate(0f, 180f, 0f);
                facingRight = false;
            }
        } else {
            facingRight = true;
            if (facingLeft && row != null) {
                row.transform.Rotate(0f, 180f, 0f);
                facingLeft = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Patrols")) {
            if (Time.time >= nextAttackTime && playerStats != null) {
                playerStats.takeDamage(damagePatrols);
                nextAttackTime = Time.time + attackRate;
            }
            rb.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        string colTag = collision.gameObject.tag;
        if (colTag == "Coins" || colTag == "Gems" || colTag == "Stars" || 
            colTag == "Heart" || colTag == "Sword" || colTag == "Shield") {
            Destroy(collision.gameObject);
        }
    }

    public void reSpawn() {
        GameObject spawnPoint = GameObject.FindWithTag("ReSpawn");
        if (spawnPoint != null) {
            transform.position = spawnPoint.transform.position;
        }
    }

    public void destroy() {
        Destroy(gameObject, 5.0f);
        isDead = true;
    }

    public bool isDeadStatus() {
        isDead = true;
        return isDead;
    }

    private void CreateDust() {
        if (dust != null) {
            dust.Play();
        }
    }
}