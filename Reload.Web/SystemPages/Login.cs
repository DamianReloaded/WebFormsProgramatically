using System;
using System.Web.UI.HtmlControls;
namespace Reload.Web.SystemPages
{
    public class Login : HtmlPage
    {
        public Login()
        {
            Scripts.Add("library/jquery/jquery-1.11.2.min.js");
            Scripts.Add("library/bootstrap/bootstrap.min.js");
            StyleSheets.Add("library/bootstrap/bootstrap.min.css");
            StyleSheets.Add("library/css/default/login.css");

            LoadContent += (object sender, EventArgs e) =>
            {
                Title.InnerText = "Login";
                HtmlGenericControl divWrapper = new HtmlGenericControl("div");
                divWrapper.Attributes["class"] = "wrapper fadeInDown";

                if (!Page.IsPostBack)  divWrapper.Attributes["style"] = "-webkit-animation-duration: 1s; animation-duration: 1s;";

                HtmlGenericControl divFormContent = new HtmlGenericControl("div");
                divFormContent.ID = "formContent";

                HtmlGenericControl divIcon = new HtmlGenericControl("div");
                divIcon.Attributes["class"] = "fadeIn first";
                HtmlImage imgIcon = new HtmlImage();
                imgIcon.ID = "icon";
                imgIcon.Src = "library/css/default/login01.svg";
                imgIcon.Attributes["class"] = "icon";
                divIcon.Controls.Add(imgIcon);

                HtmlInputText txtLogin = new HtmlInputText();
                txtLogin.ID = "login";
                txtLogin.Name = "login";
                txtLogin.Attributes["class"] = "fadeIn second";
                txtLogin.Attributes["placeholder"] = "login";
                HtmlInputPassword txtPassword = new HtmlInputPassword();
                txtPassword.ID = "password";
                txtPassword.Name = "password";
                txtPassword.Attributes["class"] = "fadeIn third";
                txtPassword.Attributes["placeholder"] = "password";
                HtmlInputSubmit btnSubmit = new HtmlInputSubmit();
                btnSubmit.Attributes["class"] = "fadeIn fourth";
                btnSubmit.Value = "Log In";

                HtmlGenericControl divFooter = new HtmlGenericControl("div");
                divFooter.ID = "formFooter";

                HtmlAnchor link = new HtmlAnchor();
                link.Attributes["class"] = "underlineHover";
                link.InnerText = "¿Olvidó su Contraseña?";
                link.HRef = "/";
                divFooter.Controls.Add(link);

                divFormContent.Controls.Add(divIcon);
                divFormContent.Controls.Add(txtLogin);
                divFormContent.Controls.Add(txtPassword);

                if (Page.IsPostBack && true)
                {
                    HtmlGenericControl spanInvalid = new HtmlGenericControl("span");
                    spanInvalid.Attributes["class"] = "invalidPassword";
                    spanInvalid.InnerText = "Contraseña Incorrecta";
                    divFormContent.Controls.Add(spanInvalid);
                }

                divFormContent.Controls.Add(btnSubmit);
                divFormContent.Controls.Add(divFooter);
                divWrapper.Controls.Add(divFormContent);
                Form.Controls.Add(divWrapper);

            };
        }
    }
}
