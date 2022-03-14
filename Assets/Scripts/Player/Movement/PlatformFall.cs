using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D m_ObjectCollider;
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && Input.GetKey("s"))
        {
            m_ObjectCollider.isTrigger = true;

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform"&& GetComponent<PlayerSwing>().attached == false)
        {
            m_ObjectCollider.isTrigger = false;

        }
        
    }
}
