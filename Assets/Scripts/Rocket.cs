using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;
    
    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        // Rocket 스크립트를 수정하여 버튼을 클릭했을 때 동작할 Shoot 메소드를 구현하세요.
        // Rigidbody2D.AddForce 메소드를 활용하여 하늘로 높이 날려보낼 것입니다.
        // 또, 연료(fuel)는 처음 100이다가, Shoot을 누를 때마다 10만큼 감소하게 수정하세요.
        
        if(fuel > 0)
        {
            _rb2d.AddForce(Vector3.forward * SPEED);
            fuel -= 10f;
        }
    }
}
