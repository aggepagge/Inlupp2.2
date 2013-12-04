using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Smoke.Controller;

namespace Smoke.View
{
    class Camera
    {
        private int screenWidth;
        private int screenHeight;

        private float scaleX;
        private float scaleY;

        private float widthMargin = 0;
        private float heightMargin = 0;

        internal Camera(Viewport viewPort)
        {
            //Sätter bredd och höjd i pixlar
            this.screenWidth = viewPort.Width;
            this.screenHeight = viewPort.Height;

            //Räknar ut skalan bassserat på pixel-bredd och höjd multiplicerat med
            //logisk bredd och höjd
            this.scaleX = (float)screenWidth / XNAController.boardLogicWidth;
            this.scaleY = (float)screenHeight / XNAController.boardLogicHeight;

            //Sätter bredd och höjd till samma storlek basserat på den minsta av de två
            if (scaleY < scaleX)
            {
                widthMargin = (screenWidth - screenHeight) / 2;
                scaleX = scaleY;
            }
            else if (scaleY > scaleX)
            {
                heightMargin = (screenHeight - screenWidth) / 2;
                scaleY = scaleX;
            }
        }

        //Returnerar en Vector2 med visuella kordinater
        internal Vector2 getVisualCoordinates(Vector2 logicPossition)
        {
            return new Vector2((logicPossition.X * scaleX), (logicPossition.Y * scaleY));
        }

        //Returnerar en Rektangel med visuella kordinater
        internal Rectangle getSmokeCoordinates(float modelX, float modelY, float modelDimention)
        {
            return new Rectangle(
                                    (int)((modelX * scaleX) + (int)(widthMargin)) - (int)((modelDimention * scaleX) / 2),
                                    (int)((modelY * scaleY) + (int)(heightMargin)) - (int)((modelDimention * scaleX) / 2),
                                    (int)(modelDimention * scaleX),
                                    (int)(modelDimention * scaleY)
                                );
        }

        //Returnerar int med skalan (För X, men den är densamma som Y)
        internal int GetScale()
        {
            return (int)scaleX;
        }

        //Returnerar float med skalan (För X, men den är densamma som Y)
        internal float GetDimention()
        {
            return scaleX;
        }
    }
}
