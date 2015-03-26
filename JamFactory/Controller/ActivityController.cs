using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Controller for group E
namespace JamFactory.Controller
{
    public class ActivityController
    {
        //Model.Activity activity;
        List<Model.Activity> ActivityList = new List<Model.Activity>();
        List<string> EmployeeList = new List<string>();
        Model.Activity activity;
        //public List<Model.Control> Activities = new List<Model.Control>();
        /*
        public void AddControl(Model.Control activity, int personID, int productID)
        {
            activity.Employee = Database._3DatabaseController.GetEmployeeFromPersonID(personID).FirstOrDefault();
            activity.Product = Database._3DatabaseController.GetProductFromID(productID).FirstOrDefault();
            Database._3DatabaseController.CreateControl(activity);
            Activities.Add(activity);
        }
        */
        public void AddControl2(string addname, string adddescription, string addtimecheck, int addproductid, int addemployeeid) {
            Model.Control control = new Model.Control(addname, adddescription, addtimecheck);
            control.Product = Database._3DatabaseController.GetProductFromID(addproductid).FirstOrDefault();
            control.Employee = Database._3DatabaseController.GetEmployeeFromPersonID(addemployeeid).FirstOrDefault();
            control.Activitys = ActivityList;
            Database._3DatabaseController.AddControl(control);
            //ActivityList.Clear();
        }
        /*
        public void AddMeasurement(Model.Control activity)
        {
            foreach (Model.Activity measurement in activity.Measurements)
            {
                Database._3DatabaseController.CreateMeasurement(activity, measurement);
            }
        }
        */

        public List<string> GetAllEmployee(int AllorNot) {
            if (AllorNot == 1) {
                foreach (Model.Employee employee in Database._3DatabaseController.GetEmployeeFromPersonID(0)) {
                    EmployeeList.Add(employee.Name + ", ID: " + employee.ID);
                    //return EmployeeList;
                }
            }
            else if (AllorNot == 2) {
                foreach (Model.Employee employee in Database._3DatabaseController.GetEmployeeFromPersonID(0)) {
                    EmployeeList.Add(employee.Name);
                    //return EmployeeList;
                }
            }
            return EmployeeList;
        }

        public int GetPersonId(int index) {
            int ID = Database._3DatabaseController.GetEmployeeFromPersonID(0)[index].ID;
            return ID;
        }

        public void AddActivity(string Title, string Description, string Details, DateTime Time, string ExpectedResult, string ActualResult) {
            activity = new Model.Activity(Title, Description, Details, Time, ExpectedResult, ActualResult);
            ActivityList.Add(activity);
        }
    }
}
