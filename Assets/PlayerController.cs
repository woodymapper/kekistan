using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 movementVector;
    Transform bulletSpawn;
    int hp = 10;
    public float bulletSpeed = 20f;
    public GameObject bulletPrefab;
    public float PlayerSpeed = 2;
    public GameObject hpbar;
    Scrollbar hpScrollBar;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("gun");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, movementVector.x, 0));
        // transform.position = new Vector3(transform.position.x + movementVector.x * Time.deltaTime,
        //    0,
        //  transform.position.z + movementVector.y *Time.deltaTime);
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime * PlayerSpeed);
    }

    void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();
        Debug.Log(movementVector.ToString());

    }
    void OnFire()
    {

        GameObject Bullet = Instantiate(bulletPrefab, bulletSpawn );
        Bullet.transform.parent = null;
        Bullet.GetComponent<Rigidbody>().AddForce(Bullet.transform.forward * bulletSpeed, ForceMode.VelocityChange);
        Destroy(Bullet, 10);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            --hp;
            if (hp <= 0) { Die(); }
            hpScrollBar.size = hpScrollBar.size - 0.1f;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector*5, ForceMode.Impulse);

        }
    }

    void Die()
    {

     
    }


}
