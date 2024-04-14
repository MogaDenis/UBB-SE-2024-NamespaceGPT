using System.Windows.Controls;

namespace NamespaceGPT.WPF
{
    public class Session
    {
        public int UserId { get; set; } = 0;
        public Frame Frame { get; set; } = null!;
        private static readonly Session instance = new();

        public static Session GetInstance()
        {
            return instance;
        }
    }
}
