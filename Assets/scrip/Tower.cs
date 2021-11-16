using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))] //tower будет знать о towerbuilder
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<block> _blocks; // хранение блоков 

    public event UnityAction<int> SizeUpdate;
    void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
       _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit; // подписываемся
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit; // отписываемся 

        _blocks.Remove(hitedBlock); // убираем из списка

        foreach (var block in _blocks) // сдвигаем каждый блок
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }
}
//не понимаю что такое инвок события итд 