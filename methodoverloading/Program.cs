namespace methodoverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Program program = new Program();
           var res= program.Add(1, 2, 34);
            var res1=program.Add(1.1, 2.4, 6.7);
            Console.WriteLine(res);
            Console.WriteLine(res1);
        }
        public int Add(int a,int b,int c)
        {
            return a + b + c;   
        }
        public double Add(double a,double b,double c)
        {
            return a+ b + c;
        }
    }
}
