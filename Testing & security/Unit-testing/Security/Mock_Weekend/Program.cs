namespace Mock_Weekend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var date = new DateGetter();
            var greet = new Greeter(date);

            //is het weekend

            Console.WriteLine(greet.GetMessage());
        }
    }
}
