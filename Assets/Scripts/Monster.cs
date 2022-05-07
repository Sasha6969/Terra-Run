using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector]
    public float speed;

    private Rigidbody2D mybody;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }


}//class





























