using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoke.Model
{
    class SmokeModel
    {
        public Level Level { get; private set; }

        //Initsierar Level-objektet
        internal SmokeModel()
        {
            Level = new Level();
        }
    }
}
