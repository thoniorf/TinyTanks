using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawer : MonoBehaviour
{
    [field: SerializeField]
    public Character character { get; private set; }

    [field: SerializeField]
    private Bullet _bullet { get; set; }

    [field: SerializeField]
    private Transform _spawnOrigin { get; set; }

    private void OnEnable()
    {
        if (character != null)
        {
            character.AttackEvent += SpawnBullet;
        }
    }

    private void OnDisable()
    {
        if (character != null)
        {
            character.AttackEvent -= SpawnBullet;
        }

    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(_bullet.gameObject, _spawnOrigin.position, _spawnOrigin.rotation);
    }
}
