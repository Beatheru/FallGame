using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public Vector2 speedRange;

    void Update()
    {
        float speed = Mathf.Lerp(speedRange.x, speedRange.y, Difficulty.getDifficulty());
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));

        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.y) 
            Destroy(gameObject);
    }
}
