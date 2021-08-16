using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using TestProjectApi.Core;

namespace TestProjectApi.BaserTestLogic
{
    public class BaseLogic
    {
        public bool checkFilterByParam<T>(string param, string prop, List<T> listObj)
        {
            bool check = true;
           
            foreach (var n in listObj)
            {
                if (GetPropertyValue(n, prop) != param)
                {
                    check = false;
                    break;
                }
                else check = true;
            }
            return check;
        }

        public bool checkIsNotEmpty<T>(string prop, List<T> listObj)
        {
            bool check = true;
            foreach (var n in listObj)
            {
                if (GetPropertyValue(n, prop) == "")
                {
                    check = false;
                    break;
                }
                else check = true;
            }
            return check;
        }

        public string GetPropertyValue<T>(T source, string propertyName)
        {
            try
            {
                return source.GetType().GetProperty(propertyName).GetValue(source, null) as string;
            }
            catch(Exception e) { return null; }
        }
    }
}
