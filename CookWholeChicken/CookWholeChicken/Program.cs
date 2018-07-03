using Common;
using CookChicken.Interface;
using CookChiken.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CookChicken
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=======Start===========");
            try
            {
                CantoneseChicken cantoneseChicken = new CantoneseChicken();
                cantoneseChicken.Chief = "CantoneseChief";
                cantoneseChicken.Leeks = "CantonLeeks";
                cantoneseChicken.Ginger = "CantonGinger";
                cantoneseChicken.ChickenDices = "CantonChicken";
                Display<CantoneseChicken>(cantoneseChicken);
                cantoneseChicken.ShowUniSkill();
                cantoneseChicken.StirFry += cantoneseChicken.PutGingerIn;
                cantoneseChicken.StirFry += cantoneseChicken.PutLeeksIn;
                cantoneseChicken.StirFry += cantoneseChicken.PutChickenIn;
                cantoneseChicken.StirFry += () => { Console.WriteLine("Put sugar in."); };
                cantoneseChicken.SetOilTemperature(110);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.Read();
        }

        private static void Display<T> (T model) where T: AbstractChiefs, ICharge
        {
            Type t = typeof(T);
            foreach (PropertyInfo info in t.GetProperties())
            {
                LogHelper.WriteLog($"Value of {t.FullName}'s {info.Name} is: '{info.GetValue(model)}'");
            }

            foreach (FieldInfo field in t.GetFields())
            {
                LogHelper.WriteLog($"Value of {t.FullName}'s {field.Name} is: '{field.GetValue(model)}'");
            }

            model.Play();
            model.Prologue();
            
            model.Closure();

            model.Charge();
        }
    }
}
