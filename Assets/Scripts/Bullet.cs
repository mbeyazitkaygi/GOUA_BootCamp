using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; // Mermi hedefi

    public float bulletSpeed = 70f; // Mermi hızı
    public GameObject impactEffect; // Çarpışma efekti
    public void Seek(Transform _target) // Hedefi ayarla
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        // Hedefe doğru hareket et
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        // Hedefe ulaşıldığında
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(); // Hedefe ulaşma işlemini gerçekleştir
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World); // Mermiyi ileri doğru hareket ettir

    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation); // Çarpışma efektini oluştur
        Destroy(effectIns, 2f); // Efekti belirli bir süre sonra yok et
        //Destroy(target.gameObject); // Hedefi ve mermiyi yok et
        Debug.Log("Vurdum oni"); // Hedefi vurduğunu logla
        Destroy(gameObject); // Mermiyi yok et
    }
}
