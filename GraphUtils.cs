using System;

namespace ConsolePlot{

    class GraphUtils{

        //General Information:
        //  LU: "Length Unit"

        //Scale for the x-Axis
        //scaleX = 1 -> 1Pixel = 1LU
        //scaleX = 2 -> 2Pixel = 1LU
        public float scaleX;
        public float scaleY;

        public delegate double function(double x);

        private Plotter plotter;

        public GraphUtils(Plotter p, float scaleX, float scaleY){
            this.plotter = p;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
        }

        public void plotGraph(function f){

            //Define variables
            int currPixX, currPixY, nextPixX, nextPixY;
            double currX, currY, nextX, nextY;

            //Init varialbes
            currPixX = -plotter.OffsetX;

            //While the pixel is on the screen
            while(plotter.canBePlotted(currPixX,0)){
                
                (currX,_) = pixelToCos(currPixX,0);
                currY = f(currX);

                (_,currPixY) = cosToPixel(0,currY);

                if(plotter.canBePlotted(currX,currY)){

                    plotter.plotPixel(currPixX,currPixY);

                }else{
                    currPixX++;
                }
            }

        }

        public double df(function f,double x){
            double h = 0.00000001;
            return (f(x+h)-f(x))/h;
        }

        private (int,int) cosToPixel(double x, double y){
            x = x * scaleX;
            y = y * scaleY;

            if(y > 0){
                y = Math.Ceiling(y);
            }
            if(y < 0){
                y = Math.Floor(y);
            }

            x = Math.Round(x,MidpointRounding.ToEven);

            return ((int)x,(int)y);
        }

        private (double,double) pixelToCos(int x, int y){
            return (x / scaleX,y / scaleY);
        }
    }
}