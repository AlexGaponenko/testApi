using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using RestSharp;
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
        /// <summary>
        /// Checks if the object contains an value by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prop"></param>
        /// <param name="listObj"></param>
        /// <returns>Return false if property empty or not equal value</returns>
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

        /// <summary>
        /// Checks if the object contains an empty value by property name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prop"></param>
        /// <param name="listObj"></param>
        /// <returns>Return true if property empty; false if not empty</returns>
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

        /// <summary>
        /// Get the value of the property according to the DTO object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns>Return null if property not present in object</returns>
        public string GetPropertyValue<T>(T source, string propertyName)
        {
            try
            {
                return source.GetType().GetProperty(propertyName).GetValue(source, null) as string;
            }
            catch(Exception e) { return null; }
        }

        /// <summary>
        /// Takes the response and compares it to the schema
        /// </summary>
        /// <typeparam name="TSchema"></typeparam>
        /// <param name="response"></param>
        /// <returns>Return true if response content contains value equal schema</returns>
        public bool IsJsonValid<TSchema>(IRestResponse response)
        {
            bool checkSchema = false;
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(TSchema));
            schema.AllowAdditionalProperties = false;
            JArray a = JArray.Parse(response.Content);
            foreach(var n in a)
            {
                string nnn = n.ToString();
                checkSchema = n.IsValid(schema);
                if (checkSchema == false) break;
            }
            return checkSchema;
        }
    }
}
