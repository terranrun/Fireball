using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform _shootPoint; // точка из которой мы стреляем
    [SerializeField] private Bullet _bulletTemplate;// шаблон
    [SerializeField] private float _delayBetweenShoots;// задержка между выстрелами
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShoot;//время которое прошло с прошлого выстрела

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if(Input.GetMouseButton(0))
        {
            if(_timeAfterShoot > _delayBetweenShoots )
            {
                Shoot(); // выстрел 
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;// сброс
            }
        }
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector3.right * moveX * -10.0f * Time.deltaTime);
    }
    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }
}
