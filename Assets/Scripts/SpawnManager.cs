using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const float Seconds = 2.0f;
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _EnemyContainer;

    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning = false)
        {
            Vector3 posToSpawn = new Vector3( 11, Random.Range(-4.4f, 4.4f), 0);
            GameObject newEnemy = Instantiate(_EnemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(2.0f);
        }

    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }



}
