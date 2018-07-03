using Common;
using CookChicken.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookWholeChicken
{
    /// <summary>
    /// This factory is used to create new cuisine.
    /// Data is stored in 
    /// </summary>
    public class SimpleFactory
    {

        public static T Create<T>() where T : AbstractChiefs, ICharge
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"ConfigFiles\\{typeof(T).Name}.json");
            string info = File.ReadAllText(path);
            T model = JsonHelper.JsonToObj<T>(info);
            return model;
        }
    }
}
