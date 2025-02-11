using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public enum PaddleType { Bottom, Right, Top, Left }  // Paddle 类型枚举
    public PaddleType paddleType;

    public float moveSpeed = 5f;  // Paddle 移动速度

    private Vector3 moveDirection;

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        float moveAmount = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MovePaddle(-moveAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MovePaddle(moveAmount);
        }
    }

    private void MovePaddle(float moveAmount)
    {
        switch (paddleType)
        {
            case PaddleType.Bottom:
                moveDirection = new Vector3(moveAmount, 0, 0);  // 左右移动
                break;
            case PaddleType.Right:
                moveDirection = new Vector3(0, moveAmount, 0);  // 上下移动
                break;
            case PaddleType.Top:
                moveDirection = new Vector3(-moveAmount, 0, 0); // 反向左右移动
                break;
            case PaddleType.Left:
                moveDirection = new Vector3(0, -moveAmount, 0);  // 反向上下移动
                break;
        }

        transform.position += moveDirection;  // 应用移动
    }
}
