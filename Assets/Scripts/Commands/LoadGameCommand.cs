using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums;
using System.Threading.Tasks;

namespace Commands
{
    public class LoadGameCommand
    {
        public int OnLoadGameData(SaveStates state)
        {
            if (state != SaveStates.Score) return ES3.Load<int>("Score");
            else if (state == SaveStates.Level) return ES3.Load<int>("Level");
            else return 0;
        }
    }
}
