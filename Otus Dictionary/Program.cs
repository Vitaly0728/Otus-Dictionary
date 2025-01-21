namespace Otus_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new OtusDictionary();

            dict.Add(1, "Apple");
            dict.Add(2, "Banana");
            dict.Add(33, "Orange");

            
            Console.WriteLine(dict.Get(1));
            Console.WriteLine(dict.Get(2));

            
            dict[4] = "Grape";
            Console.WriteLine(dict[4]);
            
            try
            {
                dict.Add(1, "Another Apple");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine(dict.Get(5));
        }
    }
}
