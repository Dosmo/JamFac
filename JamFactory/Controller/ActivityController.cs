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
        public List<Model.Control> Activities = new List<Model.Control>();
        public void AddControl(Model.Control activity, int personID, int productID)
        {
            activity.Employee = Database._3DatabaseController.GetEmployeeFromPersonID(personID).FirstOrDefault();
            activity.Product = Database._3DatabaseController.GetProductFromID(productID).FirstOrDefault();
            Database._3DatabaseController.CreateControl(activity);
            Activities.Add(activity);
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
        public void AddActivity(string Title, string Description, string Details, DateTime Time, string ExpectedResult, string ActualResult) {
            Model.Activity activity = new Model.Activity(Title, Description, Details, Time, ExpectedResult, ActualResult);
            ActivityList.Add(activity);
        }
    }
}
