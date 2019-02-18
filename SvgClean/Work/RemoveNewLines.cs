namespace SvgClean.Work
{
    // Replace all newlines with spaces
    internal class RemoveNewLines : IWork
    {
        public string Work(string input) => input.Replace("\r\n", " ").Replace("\n", " ");
    }
}
