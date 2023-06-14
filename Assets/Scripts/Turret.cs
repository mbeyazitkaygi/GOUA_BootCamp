using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target; // Taretin hedefi

    [Header("General")]
    [SerializeField] float rangeLimit = 15f; // Taretin etkili menzili

    [Header("Use Bullets (default)")]
    [SerializeField] float shootSpeed = 1f;  // Ateşleme hızı
    private float shootCountdown = 0f; // Ateşleme geri sayımı
    public GameObject bulletPre;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Field")]
    public string enemyTag = "Enemy";  // Düşmanların etiketi

    public Transform partToRotate; // Dönmesi gereken kısım
    public float rotateSpeed = 30f; // Dönme hızı


    public Transform shootPoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // UpdateTarget fonksiyonunu 0.5 saniye aralıklarla tekrarlayarak hedefi günceller
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // Sahnedeki düşmanları bul
        float shortestDistance = Mathf.Infinity; // En kısa mesafeyi tutmak için başlangıç değeri
        GameObject nearestEnemy = null; // En yakın düşman
        foreach (GameObject enemy in enemies) // Tüm düşmanları kontrol et
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);  // Taret ile düşman arasındaki mesafeyi hesapla
            if (distanceToEnemy < shortestDistance) // Daha önceki en kısa mesafeyi aştıysa
            {
                shortestDistance = distanceToEnemy; // Mesafeyi güncelle
                nearestEnemy = enemy; // En yakın düşmanı güncelle
            }
        }
        if (nearestEnemy != null && shortestDistance <= rangeLimit) // En yakın düşman varsa ve menzildeyse
        {
            target = nearestEnemy.transform; // Hedefi güncelle
        }
        else
        {
            target = null; // Hedef yoksa null yap
        }
    }
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (shootCountdown <= 0f)
            {
                // Ateşleme işlemi
                Shoot();
                shootCountdown = 1f / shootSpeed; // Geri sayımı yeniden başlat
            }

            shootCountdown -= Time.deltaTime; // Geri sayımı azalt
        }

    }
    void LockOnTarget()
    {
        // Taretin hedefe doğru yönelmesini sağlar
        Vector3 direc = target.position - transform.position;
        Quaternion rotationLook = Quaternion.LookRotation(direc);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, rotationLook, Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = shootPoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized * 0.5f;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);


    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPre, shootPoint.position, shootPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }
    void OnDrawGizmosSelected()  //sahnemizde seçtiğimiz turretin range'ini görebilmek için.
    {
        Gizmos.color = Color.blue;    //gözükecek range rengi.
        Gizmos.DrawWireSphere(transform.position, rangeLimit); // range hangi şekilde gözüksün ve bunu kendi range floatımıza eşitlesin.
    }
}
