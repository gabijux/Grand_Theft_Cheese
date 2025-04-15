using System;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 6f;
    bool isJumping = false;
    int maxHealth=3;
    int currentHealth=3;
    [SerializeField] UnityEngine.UI.Image healthUI;
    [SerializeField] Vector2 defaultOffset;
    [SerializeField] float positionOffset;
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text pointsUI;
    List<UnityEngine.UI.Image> healthBar;
    public int points = 0;

    Rigidbody2D rb;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        InitializeHealth();
        GainPoints(0);

    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();

        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true;
        }

        //TEMP DAMAGE CHECK
        if(Input.GetKeyDown(KeyCode.K))
        {
            Damage(1);
        }
    }
    public void JumpPad()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + jumpPower * 1.5f);
        isJumping = true;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);
    }
    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;

        if (collision.gameObject.CompareTag("cheese"))
        {
            points += 100;
        }
    }
    public void Damage(int damage)
    {
        animator.SetTrigger("TakeDmg");
        currentHealth -= damage;
        Destroy(healthBar[healthBar.Count-1]);
        healthBar.RemoveAt(healthBar.Count-1);
        if(currentHealth <=  0)
            death();
    }

    public void InitializeHealth()
    {
        healthBar = new List<UnityEngine.UI.Image>();
        
        int totalHearts = maxHealth;
        for(int i=0; i < totalHearts; i++)
        {
        var health = Instantiate(healthUI);
        health.transform.parent = canvas.transform;
        health.rectTransform.position = defaultOffset + 
                new Vector2(positionOffset*i, 0);
        healthBar.Add(health);
        }
        
    }

    public void AddHealth()
    {
        if (currentHealth < maxHealth)
        {
            var health = Instantiate(healthUI);
            health.transform.parent = canvas.transform;
            health.rectTransform.position = defaultOffset +
                new Vector2(positionOffset * healthBar.Count - 1, 0);
            healthBar.Add(health);
            currentHealth++;
        }
    }

    public void death()
    {
        //death
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void GainPoints(int pointAmount)
    {
        Debug.Log("points");
        points += pointAmount;
        pointsUI.text = "Score: " + points;
    }

}
