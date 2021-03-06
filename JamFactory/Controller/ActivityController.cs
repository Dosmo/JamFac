﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Controller for group E
namespace JamFactory.Controller
{
    public class ActivityController
    {
        List<Model.Activity> ActivityList = new List<Model.Activity>();
        List<string> EmployeeList = new List<string>();
        List<string> ProductList = new List<string>();
        Model.Activity activity;
        
        public void AddControl(string addname, string adddescription, string addtimecheck, int addproductid, int addemployeeid) {
            Model.Control control = new Model.Control(addname, adddescription, addtimecheck);
            control.Product = Database._3DatabaseController.GetProductFromID(addproductid).FirstOrDefault();
            control.Employee = Database._3DatabaseController.GetEmployeeFromPersonID(addemployeeid).FirstOrDefault();
            control.Activitys = ActivityList;
            Database._3DatabaseController.AddControl(control);
        }

        public List<string> GetAllEmployees() {  
            foreach (Model.Employee employee in Database._3DatabaseController.GetEmployeeFromPersonID(0)) {
                    EmployeeList.Add(employee.Name + ", ID: " + employee.ID);
                }
            return EmployeeList;
        }

        public int GetPersonId(int index) {
            int ID = Database._3DatabaseController.GetEmployeeFromPersonID(0)[index].ID;
            return ID;
        }

        public List<string> GetAllProducts() {
            foreach (Model.Product product in Database._3DatabaseController.GetProductFromID(0)) {
                ProductList.Add(product.ID + ", Size: " + product.Size.ToString());
            }
            return ProductList;
        }

        public int GetProductId(int index) {
            int ID = Database._3DatabaseController.GetProductFromID(0)[index].ID;
            return ID;
        }

        public void AddActivity(string Title, string Description, string Details, DateTime Time, string ExpectedResult, string ActualResult) {
            activity = new Model.Activity(Title, Description, Details, Time, ExpectedResult, ActualResult);
            ActivityList.Add(activity);
        }
    }
}
