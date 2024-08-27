using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new LoginForm());
        }
        //Select audiences.aud_num, audiences.type, audiences.name_of_building, materially_responsible.second_name, materially_responsible.first_name, materially_responsible.fathers_name  From audiences
        //inner join materially_responsible
        //On audiences.materially_responsible = materially_responsible.id
        //where audiences.materially_responsible=1
    }

    class A
    {
        private string aa;
        private string bb;

        public A(string aa, string bb)
        {
            this.aa = aa ?? throw new ArgumentNullException(nameof(aa));
            this.bb = bb ?? throw new ArgumentNullException(nameof(bb));
        }

        public override bool Equals(object obj)
        {
            return obj is A a &&
                   aa == a.aa &&
                   bb == a.bb;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    
}
