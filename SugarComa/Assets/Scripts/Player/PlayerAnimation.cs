using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region SerializeField

    [Header("Animation Flags")]
    [SerializeField] private bool _jump;
    [SerializeField] private bool _run;
    [SerializeField] private bool _land;
    [SerializeField] private bool _surprised;

    [Header("Other Scripts")]
    [SerializeField] private Animator _animator;
    #endregion

    #region Properties

    public bool IsLanding => _land;
    public bool IsJumping => _jump;
    public bool IsRunning => _run;
    public bool IsSurprised => _surprised;
    public bool IsIdle => !_run && !_land && !_jump && !_surprised;
    #endregion

    private void RunSet(int running)
    {
        _animator.SetBool("running", running != 0);
        _run = running != 0;
    }

    private void JumpSet(int jump)
    {
        _animator.SetBool("jump", jump != 0);
        _jump = jump != 0;
    }

    private void LandSet(int landing)
    {
        _animator.SetBool("landing", landing != 0);
        _land = landing != 0;
    }
    private void SurpriseSet(int surprised)
    {
        _animator.SetBool("surprised", surprised != 0);
        _surprised = surprised != 0;
    }

    //Jumping and rolling dice
    public void RollDice()
    {
        JumpSet(1);
    }

    //After jumping start running
    public void StartRunning()
    {
        RunSet(1);
    }

    //If player stops
    public void StopRunning()
    {
        RunSet(0);
    }

    //If player is stopped in Selector and selected
    public void ContinueRunning()
    {
        RunSet(1);
    }

    public void LandPlayer()
    {
        LandSet(1);
    }
}
