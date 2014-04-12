using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectSample
{
    interface IDAL
    {
        object GetByID(int id);
        void Add(object o);
    }

    class DummyDAL : IDAL
    {
        public object GetByID(int id)
        {
            Console.WriteLine("DummyDAL GetByID");
            return new object();
        }

        public void Add(object o)
        {
            Console.WriteLine("DummyDAL Add");
            return;
        }
    }

    class MainApp
    {
        private IDAL _DAL = null;

        public MainApp(IDAL DAL)
        {
            _DAL = DAL;
        }

        public void Run()
        {
            _DAL.Add(new object());
            _DAL.GetByID(5);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IDAL>().To<DummyDAL>();
            MainApp ma = new MainApp(ninjectKernel.Get<IDAL>());
            ma.Run();
            Console.ReadKey();
        }
    }
}
