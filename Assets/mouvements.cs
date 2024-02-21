using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvements : MonoBehaviour
{
    [SerializeField]
    private KeyCode leftKey = KeyCode.LeftArrow, rightKey = KeyCode.RightArrow;

    [SerializeField]
    private Rigidbody2D rgbd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            rgbd.AddForce(Vector2.left);
            if (rgbd.velocity.x > -15f)
            {
                rgbd.velocity = new Vector2(-5f, rgbd.velocity.y);
            }
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(rightKey))
        {
            rgbd.AddForce(Vector2.right);
            if (rgbd.velocity.x < 15f)
            {
                rgbd.velocity = new Vector2(5f, rgbd.velocity.y);
            }
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, 0.01f, 0);
        }

    }
}