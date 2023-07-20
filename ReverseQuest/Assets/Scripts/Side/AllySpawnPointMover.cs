public class AllySpawnPointMover : SpawnPointMover
{
    protected override void Update()
    {
        if (Ally.onAllyAttacked == null && transform.childCount >= 1)
        {
            GlobalVars.canMove = true;
            base.Update();
        }
        else
        {
            GlobalVars.canMove = false;
        }
    }
}
