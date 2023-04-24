using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _firePoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
    public void ShootBullet(Vector2 dir)
    {
        Bullet bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }
}
