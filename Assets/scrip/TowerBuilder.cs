using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize; //количество уровней
    [SerializeField] private Transform _buildPoint;// точка посторойки
    [SerializeField] private block _block;// что мы спауним

    private List<block> _blocks;// ссылки на все слои , кто из них умер итд


    

    public List<block> Build() //метод в котором просиходит сама постройка
    {
        _blocks = new List<block>(); // инициализация листа

        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++) 
        {
            block newBlock = BuildBlock(currentPoint);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }
    private block BuildBlock(Transform currentBuildPoint) // метод который создает новый блок
    {
       return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.Euler(90,0,0), _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)// точка где мы строим наш текущий блок 
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y/2 + _block.transform.localScale.y/2, _buildPoint.position.z);
    }
}


