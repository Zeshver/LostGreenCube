namespace Runner
{
    public enum ControlMusic
    {
        Play,
        Pause
    }

    public enum ControlMode
    {
        Keyboard,
        Mobile,
        Default
    }

    public class SetPlayerInput : SingletonBase<SetPlayerInput>
    {
        public ControlMode m_ControlMode;

        public ControlMusic m_ControlMusic;
    }
}