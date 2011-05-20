using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CommonUtilities
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="code"></param>
        public static void UIThread(this Control @this, Action code)
        {
            if (@this.InvokeRequired)
            {
                @this.BeginInvoke(code);
            }
            else
            {
                code.Invoke();
            }
        }

        private delegate void SetPropertyThreadSafeDelegate<TResult>(CopyDialog @this, Expression<Func<TResult>> property, TResult value);

        public static void SetPropertyThreadSafe<TResult>(this CopyDialog @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;

            var one = propertyInfo == null;
            //var two = @this.GetType().IsSubclassOf(propertyInfo.ReflectedType);
            var three = @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null;
            var two = true;

            if (one || !two || three)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
            }
        }
    }

}
