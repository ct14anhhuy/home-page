using System;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace HomePageVST.Filters.AntiModelInjection
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString AntiModelInjection(this HtmlHelper html, string modelPropertyName, object value)
        {
            return GenerateHiddenFormField(modelPropertyName, value);
        }

        public static MvcHtmlString AntiModelInjectionFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            object modelValue = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            string fieldName = ExpressionHelper.GetExpressionText(expression);

            return GenerateHiddenFormField(fieldName, modelValue);
        }

        private static MvcHtmlString GenerateHiddenFormField(string fieldName, object modelValue)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.Attributes["type"] = "hidden";
            builder.Attributes["name"] = string.Format("_{0}Token", fieldName);

            string value = GetValueFromModelValue(modelValue);
#pragma warning disable CS0618 // Type or member is obsolete
            value = MachineKey.Encode(Encoding.Unicode.GetBytes(value), MachineKeyProtection.Encryption);
#pragma warning restore CS0618 // Type or member is obsolete

            builder.Attributes["value"] = value.ToString();
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        private static string GetValueFromModelValue(object formValue)
        {
            Binary binaryValue = formValue as Binary;
            if (binaryValue != null)
            {
                formValue = binaryValue.ToArray();
            }
            byte[] byteArrayValue = formValue as byte[];
            if (byteArrayValue != null)
            {
                formValue = Convert.ToBase64String(byteArrayValue);
            }
            return formValue.ToString();
        }
    }
}