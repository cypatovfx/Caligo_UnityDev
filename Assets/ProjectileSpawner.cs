using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public float spawnDelay = 1f; // Delay between spawning projectiles
    public Vector2 spawnRange = new Vector2(-5f, 5f); // Range of positions where projectiles can spawn

    private void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }

    private System.Collections.IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            // Calculate a random position within the spawn range
            float spawnX = Random.Range(spawnRange.x, spawnRange.y);
            Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, transform.position.z);

            // Spawn the projectile at the random position
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            // Set the projectile's Z position to zero to ensure it's in the 2D plane
            projectile.transform.position = new Vector3(projectile.transform.position.x, projectile.transform.position.y, 0f);

            // Wait for the specified delay before spawning the next projectile
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
