using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatFacts
{
    public class Employee
    {

        public int Fred { get; set; }

        public virtual float CalculatePay()
        {
            return 0;
        }

    }

    public class HourEmployee : Employee
    {
        public override float CalculatePay()
        {
            return 5 * .23f;
        }
    }

    public class SalaryEmployee : Employee
    {
        public override float CalculatePay()
        {
            return base.CalculatePay();
        }
    }


    public class ConsumingClass
    {
        public ConsumingClass(Employee controller)
        {
            controller.CalculatePay();
        }
    }

    public class ConsumingConsumingClass
    {
        public ConsumingConsumingClass()
        {
            new ConsumingClass(new HourEmployee()); //
            new ConsumingClass(new Employee()); //
            new ConsumingClass(new SalaryEmployee()) //
        }
    }
}