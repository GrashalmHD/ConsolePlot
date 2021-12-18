using System;

namespace ConsolePlot{

    class Plotter{

        public readonly int OffsetX,OffsetY;

        public Plotter(int OffsetX,int OffsetY){
            this.OffsetX = OffsetX;
            this.OffsetY = OffsetY;
            setupConsole();
        }

        public Plotter(){
            this.OffsetX = Console.WindowWidth / 2;
            this.OffsetY = Console.WindowHeight / 2;
        }   

        public void setupConsole(){
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.ASCII;
        }

        public void plotPixel(int x, int y){
            if(canBePlotted(x,y)){
                Console.SetCursorPosition(x+OffsetX,OffsetY-y);
                Console.Write('*');
            }
        }

        public bool canBePlotted(int x, int y){
            //Check if coordinates are inside of the visible console
            if((x+OffsetX+1 > 0) && (x+OffsetX < Console.WindowWidth+1) && (OffsetY-y+1 > 0) && (OffsetY-y < Console.WindowHeight+1)){
                return true;
            }
            return false;
        }

        public bool canBePlotted(double x, double y){
            return canBePlotted((int)x,(int)y);
        }

        public void plotCoSy(){
            for(int i = 0; i < Console.WindowWidth; i++){
                Console.SetCursorPosition(i,OffsetY);
                Console.Write("-");
            }
            for(int i = 0; i < Console.WindowHeight; i++){
                Console.SetCursorPosition(OffsetX,i);
                Console.Write("|");
            }
        }

    }
}