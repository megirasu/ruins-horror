using UnityEngine;

public class lightsphere : MonoBehaviour
{
    //プレイヤーの距離その他パラメーター
    [SerializeField] private Transform Player;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float runAwayDistance = 10f; 
    [SerializeField] private float acceleration = 8f;

    // 上下するための変数
    [SerializeField] private float bobbingSpeed = 2f;
    [SerializeField] private float bobbingHeight = 0.3f;
    [SerializeField] private float hoverHeight = 1.5f;

    private float currentSpeed = 0f;//速さ
    private float startY; //記録

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        if (Player == null) return;
    //プレイヤーとの距離の処理
        float distToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distToPlayer < runAwayDistance)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.deltaTime);
        }

        
        //上下の動きと段差を登らすためのやつ
        Vector3 pos = transform.position + transform.forward * currentSpeed * Time.deltaTime;

        if (Physics.Raycast(pos , Vector3.down, out RaycastHit hit, 20f))
        {
            float groundY = hit.point.y;
            pos.y = groundY + hoverHeight + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        } 
        
        transform.position = pos;
    }
}