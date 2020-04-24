using UnityEngine;

public struct InputController
{
    private readonly Vector3 startPos;
    private readonly float startSwipeTime;

    public InputController(Vector3 _startPos, float _startSwipeTime)
    {
        startPos = _startPos;
        startSwipeTime = _startSwipeTime;
    }

    public Vector3 FindDirection(Vector3 endPos, float endSwipeTime)
    {
        if(endSwipeTime - startSwipeTime > Const.SwipeTime)
            return  Vector3.zero;

        var resultVec = startPos - endPos;
        if (Mathf.Abs(resultVec.x) > Mathf.Abs(resultVec.y))
            return resultVec.x > 0 ? Vector3.right : Vector3.left;

        return resultVec.y > 0 ? Vector3.forward : Vector3.back;
    }
}
