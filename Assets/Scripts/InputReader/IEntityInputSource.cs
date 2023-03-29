namespace InputReader
{
    public interface IEntityInputSource
    {
        public float HorizontalDirection { get; }

        public bool Jump { get; }

        public void ResetOneTimeActions();
    }
}
