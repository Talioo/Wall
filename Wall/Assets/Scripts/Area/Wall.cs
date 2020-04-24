using System;
using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Transform TargetPosition;
    private IEnumerator moveCorutine = null;

    private const float DistanseToFinishPoint = 0.1f;
    private void OnEnable()
    {
        GameManager.Instance.StartGame += StartGame;
        GameManager.Instance.GameOver += StopGame;
    }

    private void StartGame()
    {
        moveCorutine = MoveCorutine();
        StartCoroutine(moveCorutine);
    }

    private void StopGame(bool value)
    {
        StopCoroutine(moveCorutine);
    }
    private IEnumerator MoveCorutine()
    {
        while (Math.Abs(transform.position.z - TargetPosition.position.z) > DistanseToFinishPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition.position, Const.WallSpeed * Time.deltaTime);
            yield return null;
        }
        GameManager.Instance.StopGame(true);
    }


}
