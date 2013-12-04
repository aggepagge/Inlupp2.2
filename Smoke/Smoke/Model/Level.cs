using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Smoke.Controller;

namespace Smoke.Model
{
    class Level
    {
        //Prop för startpossition (För rök)
        public Vector2 SmokePossition { get; private set; }

        //Initsierar startpossitionerna
        internal Level()
        {
            SmokePossition = new Vector2(XNAController.boardLogicWidth / 2, XNAController.boardLogicHeight * 0.9f);
        }
    }
}
