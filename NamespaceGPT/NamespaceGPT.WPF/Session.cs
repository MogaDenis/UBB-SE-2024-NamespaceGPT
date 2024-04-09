namespace NamespaceGPT.WPF
{
    public class Session
    {
        public int UserId { get; set; } = 0;

        private static readonly Session instance = new();

        public static Session GetInstance()
        {
            return instance;
        }
    }
}
