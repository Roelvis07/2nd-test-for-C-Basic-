using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace employee
{
    public partial class Form1 : Form
    {
        Employee employee;
        public Form1()
        {
            InitializeComponent();
            List < Employee > employees = new List<Employee>();
            Employee item1 = new Employee();
            item1.nombre = "A"; item1.apellido = "A1"; item1.company = "Amazon"; item1.edad = 20;

            Employee item2 = new Employee();
            item2.nombre = "B"; item2.apellido = "B1"; item2.company = "BrandsMart"; item2.edad = 35;

            Employee item3 = new Employee();
            item3.nombre = "C"; item3.apellido = "C1"; item3.company = "Google"; item3.edad = 26;

            Employee item4 = new Employee();
            item4.nombre = "D"; item4.apellido = "D1"; item4.company = "Amazon"; item4.edad = 42;

            Employee item5 = new Employee();
            item5.nombre = "E"; item5.apellido = "E1"; item5.company = "Amazon"; item5.edad = 18;

            Employee item6 = new Employee();
            item6.nombre = "F"; item6.apellido = "F1"; item6.company = "Amazon"; item6.edad = 45;

            Employee item7 = new Employee();
            item7.nombre = "G"; item7.apellido = "G1"; item7.company = "BrandsMart"; item7.edad = 65;

            Employee item8 = new Employee();
            item8.nombre = "H"; item8.apellido = "H1"; item8.company = "Google"; item8.edad = 41;

            Employee item9 = new Employee();
            item9.nombre = "I"; item9.apellido = "I1"; item9.company = "Google"; item9.edad = 33;

            Employee item10 = new Employee();
            item10.nombre = "J"; item10.apellido = "J1"; item10.company = "Amazon"; item10.edad = 27;

            employees.Add(item1); employees.Add(item2); employees.Add(item3); employees.Add(item4); employees.Add(item5);
            employees.Add(item6); employees.Add(item7); employees.Add(item8); employees.Add(item9); employees.Add(item10);

            foreach (var item in EdadPromedio(employees))
            {
                Console.WriteLine("empresa: " + item.Key + ", edad promedio: " + item.Value);
            }
            foreach (var item in CountPerCompany(employees))
            {
                Console.WriteLine("empresa: " + item.Key + ", cantidad: " + item.Value);
            }


        }
        public static Dictionary<string, int> EdadPromedio(List<Employee> employees)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var promedio = from data in employees
                           group data by data.company
                           into grouped
                               select new
                               {
                                   Company = grouped.Key,
                                   AgeAverage = Convert.ToInt32(grouped.Average(x => x.edad))
                               };
            
            foreach (var data in promedio)
            {
                result.Add(data.Company, data.AgeAverage);
            }

            return result;
        }
        public static Dictionary<string, int> CountPerCompany(List<Employee> employees)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var promedio = from data in employees
                           group data by data.company
                           into grouped
                               select new
                               {
                                   Company = grouped.Key,
                                   Count = grouped.Count()
                               };

            foreach (var data in promedio)
            {
                result.Add(data.Company, data.Count);
            }

            return result;
        }
    }
    public class Employee
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string company { get; set; }
        public int edad { get; set; }
    }
}
