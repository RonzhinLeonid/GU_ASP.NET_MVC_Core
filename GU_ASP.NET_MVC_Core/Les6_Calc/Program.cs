using System;
using Autofac;
using Calculator;

namespace Les6_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            //Геннадий, тут аналогичный вопрос как и в первом задании? Если регистрирую все действия, то как потом вызывать нужное?

            //builder.RegisterType<Division>().As<IAction>().SingleInstance();
            builder.RegisterType<Multiplication>().As<IAction>().SingleInstance();
            //builder.RegisterType<Subtraction>().As<IAction>().SingleInstance();
            //builder.RegisterType<Sum>().As<IAction>().SingleInstance();

            builder.RegisterType<Calc>().As<ICalc>().SingleInstance();

            IContainer container = builder.Build();

            var calculator = container.Resolve<ICalc>();
            calculator.SetupAction(container.Resolve<IAction>());

            Console.WriteLine(calculator.Execute(2, 3));
                
        }
    }
}
