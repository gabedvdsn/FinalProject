using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ProjectilePrefab;

    Vector2 lookDir;
    float lookAngle;

    void Update()
    {
        lookDir = Camera.main.WorldToScreenPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
    }

    public void Shoot_()
    {
        FireProj();

    }

    public void FireProj()
    {
        GameObject proj = Instantiate(ProjectilePrefab);
        proj.transform.position = firePoint.position;
        proj.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        proj.GetComponent<Rigidbody2D>().velocity = firePoint.right * BowAttributes.ProjectileSpeed;
    }

    public void Shoot(GameObject Hero)
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 difference = mousePos;

        float distance = difference.magnitude;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Debug.Log(rotationZ);

        Vector2 direction = difference / distance;
        direction.Normalize();

        FireProjectile(Hero, direction, rotationZ);
    } 

    private void FireProjectile(GameObject Hero, Vector2 dir, float rotationz)
    {
        GameObject proj = Instantiate(ProjectilePrefab) as GameObject;
        proj.transform.position = Hero.gameObject.transform.position;
        proj.transform.rotation = Quaternion.Euler(0f, 0f, rotationz);
        proj.GetComponent<Rigidbody2D>().velocity = dir * BowAttributes.ProjectileSpeed;
    }
}
