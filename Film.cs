using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Zad_5
{
    class Film
    {
        public string Title;
        public DateTime Date;
        public string Desc;

        public Film(string _title, DateTime dateTime, string Desc)
        {
            this.Title = _title;
            this.Date = dateTime;
            this.Desc = Desc;
        }
        public override string ToString()
        {
            return Title;
        }

    }
}
