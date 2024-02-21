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
        }
        if (Input.GetKey(rightKey))
        {
            rgbd.AddForce(Vector2.right);
        }
    }
}