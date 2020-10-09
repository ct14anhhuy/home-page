using System;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace HomePageVST.Extensions.AntiModelInjection
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ValidateAntiModelInjectionAttribute : ActionFilterAttribute
    {
        private string _propertyName;

        public ValidateAntiModelInjectionAttribute(string propertyName)
        {
            _propertyName = propertyName;
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("The propertyName value must be a non empty string.");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string encryptedPropertyName = string.Format("_{0}Token", _propertyName);
            string hashToken = filterContext.HttpContext.Request.Form[encryptedPropertyName];
            if (string.IsNullOrEmpty(hashToken))
            {
                throw new MissingFieldException(string.Format("The hidden form field named value {0} was missing. This is created by the Html.AntiModelInjection methods. Ensure the name used on your [ValidateAntiModelInjectionAttribute(\"!HERE!\")] matches the field name used in Html.AntiModelInjection method. If this attribute is used on a controller method that is meant for HttpGet, then the form value would not yet exist. This attribute is meant to be used on controller methods accessed via HttpPost.", encryptedPropertyName));
            }
            string formValue = filterContext.HttpContext.Request.Form[_propertyName];
            if (string.IsNullOrEmpty(formValue))
            {
                throw new MissingFieldException(string.Format("The form value {0} was missing. If this attribute is used on a controller method that is meant for HttpGet, then the form value would not yet exist. This attribute is meant to be used on controller methods accessed via HttpPost.", _propertyName));
            }
#pragma warning disable CS0618 // Type or member is obsolete
            byte[] plainTextBytes = MachineKey.Decode(hashToken, MachineKeyProtection.Encryption);
#pragma warning restore CS0618 // Type or member is obsolete
            string plainText = Encoding.Unicode.GetString(plainTextBytes);
            if (string.Compare(plainText, formValue, false, CultureInfo.InvariantCulture) != 0)
            {
                throw new HttpAntiModelInjectionException(string.Format("Failed security validation for {0}. It is possible the data was tampered with as the original value used to create the form field does not match the current property value for this field. Ensure if this is a web farm, the machine keys are the same.", _propertyName));
            }

            filterContext.HttpContext.Trace.Write("(Logging Filter)Action Executing: " + filterContext.ActionDescriptor.ActionName);

            base.OnActionExecuting(filterContext);
        }
    }
}