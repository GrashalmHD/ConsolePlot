using System;

namespace ConsolePlot
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Plotter p = new Plotter();

            GraphUtils u = new GraphUtils(p,1,1);
            p.plotCoSy();
            
            u.plotGraph(f);


            Console.SetCursorPosition(Console.WindowWidth,Console.WindowHeight);
        }

        static double f(double x){
            return x*x;
        }
    }
}
