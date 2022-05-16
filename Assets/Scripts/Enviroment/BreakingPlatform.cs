using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 ogTrans;
    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay = 0.003f;
    public float shake_intensity = .15f;
    public bool isShaking = false;
    private float temp_shake_intensity = 0;
    GameObject spriteg;
    Sprite spritag;

    private void Awake()
    {
        spriteg = transform.GetChild(0).gameObject;
    }

    

    void Update()
    {
        if (temp_shake_intensity > 0 && isShaking == true)
        {
            spriteg.transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            spriteg.transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shake_decay;
        }
        else
        {
            isShaking = false;
        }
    }

    public void Shake()
    {
        if (!isShaking)
        {
            isShaking = true;
            originPosition = spriteg.transform.position;
            originRotation = spriteg.transform.rotation;
            temp_shake_intensity = shake_intensity;
        }
    }
    public void Start()
    {
        ogTrans = gameObject.GetComponent<Transform>().position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
        {
        Shake();
        yield return new WaitForSeconds(1);
        isShaking = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 6;
        StartCoroutine(Respawn());
        }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Transform>().position = ogTrans;
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
