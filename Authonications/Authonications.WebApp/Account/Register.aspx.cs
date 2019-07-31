using Auth.Core.Models;
using Auth.Managers.ActionManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authonications.WebApp.Account
{
    public partial class Register : System.Web.UI.Page
    {
        RegisterManager _RegisterManager = new RegisterManager();
        public enum MessageType { Success, Failed , Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        public void DataVisible()
        {
            lblusername.Visible = false;
            txtusername.Visible = false;
            lblpassword.Visible = false;
            txtpassword.Visible = false;
            lblconfirmpasseord.Visible = false;
            txtconfirmpassword.Visible = false;
            lblname.Visible = false;
            txtname.Visible = false;
            lblemail.Visible = false;
            txtemail.Visible = false;
        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                Registers _Registers = new Registers();
                _Registers.UserName = txtusername.Text;
                _Registers.Password = txtpassword.Text;
                _Registers.Name = txtname.Text;
                _Registers.Email = txtemail.Text;

                decimal AlreadyExistUserName = _RegisterManager.AlreadyExsitUserName(_Registers);
                if(AlreadyExistUserName>=1)
                {
                    ShowMessage("This UserName Already Registered ... Must be Unique", MessageType.Warning);
                }
                else
                {
                    decimal AlreadyExistEmail = _RegisterManager.AlreadyExsitEmail(_Registers);
                    if (AlreadyExistEmail >= 1)
                    {
                        ShowMessage("This Email Already Registered ... Must be Unique ", MessageType.Warning);
                    }
                    else
                    {
                        int successRegister = _RegisterManager.Register(_Registers);
                        if (successRegister > 0)
                        {
                            ShowMessage("Registration", MessageType.Success);
                            DataVisible();
                        }
                        else
                        {
                            ShowMessage("Please Check Your Information ", MessageType.Failed);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ShowMessage("Error : "+ ex, MessageType.Error);
            }
        }
    }
}