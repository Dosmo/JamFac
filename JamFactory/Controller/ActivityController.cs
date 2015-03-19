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
        public List<Model.Activity> Activities = new List<Model.Activity>();
        public void AddActivity(Model.Activity activity, int personID, int productID)
        {
            activity.Employee = Database._3DatabaseController.GetEmployeeFromPersonID(personID).FirstOrDefault();
            activity.Product = Database._3DatabaseController.GetProductFromID(productID).FirstOrDefault();
            Database._3DatabaseController.CreateActivity(activity);
            Activities.Add(activity);
        }
        public void AddMeasurement(Model.Activity activity)
        {
            foreach (Model.Measurement measurement in activity.Measurements)
            {
                Database._3DatabaseController.CreateMeasurement(activity, measurement);
            }
        }
    }
}
