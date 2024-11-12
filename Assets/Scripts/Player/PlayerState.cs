public interface IPlayerState
{
    void EnterState(PlayerStateController player);
    void UpdateState(PlayerStateController player);
    void ExitState(PlayerStateController player);
}