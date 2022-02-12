using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_example
{
    delegate void HizEventHandler();

    class Araba
    {
        public event HizEventHandler HizAsimi;
    
       
        private int hiz;
        public int Hiz
        {
            get => hiz;
            set
            {
                if (value > 80)
                {

                    hiz = 80;
                    if (HizAsimi!=null)
                    {
                        HizAsimi();

                    }
                }
                else
                {
                    hiz = value;
                }
            }
        }
        
    }
}
