namespace ConvertToUtf8
{
    public static class ConsoleFrontend
    {
        public static void Main(params string[] args)
        {
            var converter = new Converter();
            var program = new Program(converter);

            program.Main(args);
        }
    }
}