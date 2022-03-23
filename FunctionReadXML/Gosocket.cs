
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FunctionReadXML
{
    [XmlRoot(ElementName = "gosocket")]
    public class Gosocket
    {

        [XmlElement(ElementName = "area")]
        public List<Area> Area { get; set; }

        
        public double NumberOfAreas
        {
            get { return Area.Count; }
        }

        public int getNumberOfAreasMoreTwoEmployees()
        {
            int numberOfAreasMoreTwoEmployees = 0;
            Area.ForEach(area => numberOfAreasMoreTwoEmployees += area.HasMoreTwoEmployees ? 1 : 0);
            return numberOfAreasMoreTwoEmployees;
        }
        
    }

    [XmlRoot(ElementName = "area")]
    public class Area
    {

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "employees")]
        public Employees Employees { get; set; }

        public double GetSumOfSalaries()
        {
            double sumSalaries = 0;
            Employees.Employee.ForEach(employee => sumSalaries += employee.Salary);
            return sumSalaries;
        }

        public bool HasMoreTwoEmployees
        {
            get { return Employees.Employee.Count > 2; }
        }
    }


    [XmlRoot(ElementName = "employees")]
    public class Employees
    {

        [XmlElement(ElementName = "employee")]
        public List<Employee> Employee { get; set; }
    }

    [XmlRoot(ElementName = "employee")]
    public class Employee
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "salary")]
        public double Salary { get; set; }

        [XmlAttribute(AttributeName = "jobTitle")]
        public string JobTitle { get; set; }
    }

}
