using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    /* i dont see why the edit in line 13/14 is necessary on collectables
     * in the video tutorial he put the wrong variable in HealthCollectable
     * the variable he put was "CurrentHealth" instead of currentHealth, if the capital was changed it wouldve likely worked.
     * but i dont know, im not the teacher. just a thought. */
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float speed = 3.0f;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth+ amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
