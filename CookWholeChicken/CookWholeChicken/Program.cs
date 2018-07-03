using Common;
using CookChicken.Interface;
using CookChiken.Service;
using CookWholeChicken;
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
                {
                    ShandongChicken shandongChicken = new ShandongChicken();
                    shandongChicken.Chief = "ShandongChief";
                    shandongChicken.Leeks = "shandongLeeks";
                    shandongChicken.Ginger = "CantonGinger";
                    shandongChicken.ChickenDices = "CantonChicken";
                    Display<ShandongChicken>(shandongChicken);
                    shandongChicken.ShowUniSkill();
                    shandongChicken.ThickenJuices += () => Console.WriteLine("Make thicken juices");
                    shandongChicken.ShandongCooking();
                    //shandongChicken.StirFry += shandongChicken.PutGingerIn;
                    //shandongChicken.StirFry += shandongChicken.PutLeeksIn;
                    //shandongChicken.StirFry += shandongChicken.PutChickenIn;
                    //shandongChicken.StirFry += () => { Console.WriteLine("Put sugar in."); };
                    //shandongChicken.SetOilTemperature(200);

                }

                {
                    //Create a new ShandongChicken instance from a json file.
                    Console.WriteLine("==Create a new shandong chicken by simple factory==");
                    ShandongChicken shandongChicken = SimpleFactory.Create<ShandongChicken>();
                    Display<ShandongChicken>(shandongChicken);
                }
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
                LogHelper.WriteLogAndConsole($"Value of {t.FullName}'s {info.Name} is: '{info.GetValue(model)}'");
            }

            foreach (FieldInfo field in t.GetFields())
            {
                LogHelper.WriteLogAndConsole($"Value of {t.FullName}'s {field.Name} is: '{field.GetValue(model)}'");
            }

            model.Play();
            model.Prologue();
            
            model.Closure();

            model.Charge();
        }
    }
}
