using UnityEngine;

public class Moving : State
{
    public Moving(Block block) : base(block) { }
    public override bool DieOnCollision => true;

    private Vector3 Target
    {
        get
        {
            var target = block.StartPosition;
            target.y = block.transform.position.y;
            return target;
        }
    }

    public override void Move()
    {
        if(block.Position != Target)
            block.Position = Vector3.MoveTowards(block.Position, Target, Const.BlockSpeed * Time.deltaTime);
        else
            block.Position = Vector3.MoveTowards(block.Position, block.StartPosition, Const.BlockSpeed* Time.deltaTime);
        if(block.Position == block.StartPosition)
            ChangeState(new WasMoved(block));
    }
}
