using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject[] clouds; // Danh sách các Prefab mây (Cloud)
    public float spawnInterval = 2f; // Thời gian giữa mỗi lần spawn
    public int maxClouds = 20; // Số lượng mây tối đa
    public float minX, maxX, minZ, maxZ; // Khu vực spawn
    public float cloudHeight = 50f; // Độ cao của mây

    private int currentCloudCount = 0;

    void Start()
    {
        StartCoroutine(SpawnCloudsOverTime());
    }

    IEnumerator SpawnCloudsOverTime()
    {
        while (currentCloudCount < maxClouds)
        {
            SpawnCloud();
            currentCloudCount++;
            yield return new WaitForSeconds(spawnInterval); // Đợi vài giây rồi spawn tiếp
        }
    }

    void SpawnCloud()
    {
        if (clouds.Length == 0) return; // Nếu không có Prefab mây, thoát

        // Chọn vị trí ngẫu nhiên trong vùng spawn
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition = new Vector3(randomX, cloudHeight, randomZ);

        // Chọn một Prefab mây ngẫu nhiên
        int randomIndex = Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex], spawnPosition, Quaternion.identity);

        // Thêm script di chuyển mây vào object
        cloud.AddComponent<CloudMover>();
    }
}
