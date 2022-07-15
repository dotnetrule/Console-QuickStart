namespace ConsoleQuickStart.ConsoleManagers
{
    public interface IConsoleManager
    {
        public void Clear();
        public ConsoleKeyInfo ReadKey();
        public string ReadLine();
        public void Write(string value);
        public void WriteLine(string value);
    }
}