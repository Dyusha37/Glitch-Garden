using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField]float minSpawnDelay = 1f;
    [SerializeField]float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }
    public void StopSpawning()
    {
        spawn = false;
    }
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
