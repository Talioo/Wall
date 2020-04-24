using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReadyToMove : State
{
    public ReadyToMove(Block block) : base(block) { }
    public override bool DieOnCollision => true;
    private List<Vector3> directions = new List<Vector3>() {Vector3.right, Vector3.left, Vector3.forward, Vector3.back};

    private const float Distance = 0.5f;
    private Vector3 myDirection = Vector3.zero;

    public override void StartGame()
    {
        FindFreeNeighbour(out var neighbour);
        if (neighbour == null)
            ChangeState(new Plane(block));
        else
            StandOnNeighbour(neighbour);
    }

    private void FindFreeNeighbour(out Block freeBlock)
    {
        freeBlock = null;
        directions = directions.OrderBy(x => Guid.NewGuid()).ToList();
        foreach (var direction in directions)
        {
            RaycastHit[] raycast = Physics.RaycastAll(block.transform.position, direction, Distance);

            if (raycast.Length <= 0 || !raycast[0].collider.CompareTag(Const.BlockTag))
                continue;

            var neighbour = raycast[0].collider.GetComponent<Block>();
            if (neighbour == null)
                continue;

            if(!neighbour.currentState.FreeToPutBlock)
                continue;

            myDirection = direction;
            freeBlock = neighbour;
            break;
        }
    }

    private void StandOnNeighbour(Block target)
    {
        target.currentState.FreeToPutBlock = false;
        var targetPosition = target.transform.position;
        var transform = block.transform;
        transform.position = new Vector3(targetPosition.x,
            targetPosition.y + transform.localScale.y, targetPosition.z);
    }

    public override void Swipe(Vector3 direction)
    {
        if((direction + myDirection) == Vector3.zero)
            ChangeState(new Moving(block));
    }

}
