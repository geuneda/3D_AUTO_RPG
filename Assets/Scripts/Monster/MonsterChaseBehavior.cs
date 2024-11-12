public class MonsterChaseBehavior : IMonsterBehavior
{
    public void Execute(MonsterAI monster)
    {
        monster.ChasePlayer();
    }
}