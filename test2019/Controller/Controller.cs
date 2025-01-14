using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data.Oracle;

namespace test2019
{
    public class Controller
    {
        IView<DbColumn> view = null;
        DbColumns model = null;
        bool sendMessagesToUser = true;
        public Controller(IView<DbColumn> view, DbColumns model , bool sendMessagesToUser)
        {
            this.view = view;
            this.model = model;
            view.SetControler(this);
            this.sendMessagesToUser = sendMessagesToUser;
        }

        public bool ValidateLoginPassword()
        {
            try
            {
                model.CnData = new ConnectionData(view.User, view.Password);
                if (!model.CnData.ValidateConnectionString)
                {
                    if (sendMessagesToUser) view.ShowMessage("Incorect Login or password"); 
                    return false;
                }
            }
            catch (System.IO.FileNotFoundException ex) {
                view.ShowMessage(ex.Message);
            }
            return true;
        }
        private bool LoadData(bool showLoadDataButton)
        {
            bool isLoaded = false;
            if (!model.TestConnection())
            {
                if (sendMessagesToUser) view.ShowMessage("Connection error!");
            }
            else
            {
                if (sendMessagesToUser) view.ShowMessage("Connection successfull.");
                if(showLoadDataButton) view.ShowLoadDataButton();
                model.LoadData();
                view.LoadDataToGrid(model);
                isLoaded = true;
            }
            return isLoaded;
        }
        public bool TestConnection_Click()
        {
            bool success = false;
            if (!ValidateLoginPassword()) return false; 
            
            try
            {
                success = LoadData(true);
            }
            catch (OracleException ex) {
                if (ex.Code.ToString() == "1017")
                    if(sendMessagesToUser) view.ShowMessage("Connection error!");
                else
                    if(sendMessagesToUser) view.ShowMessage(ex.Message);
            }
            return success;
        }
        public bool LoadData_Click()
        {
            bool success = false;
            if (!ValidateLoginPassword()) return false;

            try
            {
                success = LoadData(false);
            }
            catch (OracleException ex) {
                if (ex.Code.ToString() == "1017")
                    if (sendMessagesToUser) view.ShowMessage("Connection error!");
                    else
                    if (sendMessagesToUser) view.ShowMessage(ex.Message);
            }
            return success;
        }
        public bool LoadData2_Click()
        {
            bool success = false;
            if (!ValidateLoginPassword()) return false;

            try
            {
                success = LoadData(false);
            }
            catch (OracleException ex)
            {
                if (ex.Code.ToString() == "1017")
                    if (sendMessagesToUser) view.ShowMessage("Connection error!");
                    else
                    if (sendMessagesToUser) view.ShowMessage(ex.Message);
            }
            return success;
        }
    }
}
