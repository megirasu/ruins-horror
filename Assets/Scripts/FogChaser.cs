using UnityEngine;

public class FogChaser : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float moveSpeed = 2f; // 黒い霧の追いかけるスピード

    void Update()
    {
        if (Player == null) return;
// プレイヤーの距離
        Vector3 targetPosition = Player.position;
        
        targetPosition.y = transform.position.y;

        // プレイヤーに向かって一定のスピードで進む
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // 常にプレイヤーの方を向かす
        transform.LookAt(targetPosition);
    }
}
