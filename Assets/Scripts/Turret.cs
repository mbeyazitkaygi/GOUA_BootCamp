using UnityEngine;
using System.Collections;
public class Turret : MonoBehaviour {

	private Transform target;
	[Header("General")]

	public float range = 15f;

	[Header("Use Bullets (default)")]
	public GameObject bulletPrefab;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Use Lase")]
	public bool useLase = false;
	public LineRenderer lineRenderer;

	[Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

    public Transform firePoint;
    
// Use this for initialization
	void Star () {
		InvokeRepeating("", 0f, 0.5f);
	}
	
	void UpdateTarge ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		} else
		{
			target = null;
		}
	}

    void Update () 
	{
		if (target == null)
		{
			if (useLase)
			{
				if (lineRenderer.enabled)
					lineRenderer.enabled = false;
			}

			return;
		}

        LockOnTarge();
        if (useLase)
		{
			Lase();
		} else
        {
            if (fireCountdown <= 0f)
			    {
				    Shoo();
				    fireCountdown = 1f / fireRate;
			    }

			    fireCountdown -= Time.deltaTime;
		}

    }

	void LockOnTarge ()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Lase ()
	{
		if (!lineRenderer.enabled)
			lineRenderer.enabled = true;

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);
	}

	void Shoo ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();
		if (bullet != null)
			bullet.Seek(target);
	}
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}


