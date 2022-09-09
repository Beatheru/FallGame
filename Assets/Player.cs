using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 6f;
    float screenBorder;
    Rigidbody2D myRigidBody;
    public event System.Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenBorder = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        float velocity = speed * direction;

        transform.Translate(new Vector2(velocity * Time.deltaTime, 0));

        if (transform.position.x < -screenBorder) {
            transform.position = new Vector2 (screenBorder, transform.position.y);
        }

        if (transform.position.x > screenBorder) {
            transform.position = new Vector2 (-screenBorder, transform.position.y);
        }
    }

    void OnTriggerEnter2D (Collider2D triggerCollider) {
        if (triggerCollider.tag == "Cube") {
            if (OnPlayerDeath != null)
                OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
