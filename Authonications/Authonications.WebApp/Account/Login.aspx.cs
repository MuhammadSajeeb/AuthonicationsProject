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
    public partial class Login : System.Web.UI.Page
    {
        RegisterManager _RegisterManager = new RegisterManager();
        public enum MessageType { Success, Failed, Error, Info, Warning };
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.Cookies["UserName"]!=null && Request.Cookies["Password"]!=null)
                {
                    txtusername.Text = Request.Cookies["UserName"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    RememeberCheckBox.Checked = true;
                }
            }
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
            lblRememberme.Visible = false;
            RememeberCheckBox.Visible = false;
            LoginButton.Visible = false;
            
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Registers _Registers = new Registers();
                _Registers.UserName = txtusername.Text;
                _Registers.Password = txtpassword.Text;

                decimal successLogin = _RegisterManager.Login(_Registers);
                if(successLogin>=1)
                {
                    if(RememeberCheckBox.Checked)
                    {

                        Response.Cookies["UserName"].Value = _Registers.UserName;
                        Response.Cookies["Password"].Value = _Registers.Password;

                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(15);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(15);

                        Session["UserName"] = _Registers.UserName;
                        ShowMessage("Login", MessageType.Success);
                        DataVisible();

                    }
                    else
                    {
                        
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                        Session["UserName"] = _Registers.UserName;
                        ShowMessage("Login", MessageType.Success);
                        DataVisible();


                    }


                }
                else
                {
                    ShowMessage("Login", MessageType.Failed);
                }
            }
            catch(Exception ex)
            {
                ShowMessage("Catch : "+ex, MessageType.Error);
            }
        }
    }
}