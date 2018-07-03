using Common;
using CookChicken.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookChiken.Service
{     
    /// <summary>
    /// Has three more events, which are marinate chicken,  put garlic in and thicken juices.
    /// </summary>
    public class ShandongChicken: AbstractChiefs, ICharge
    {
        public ShandongChicken()
        {
            base.temperature = 100;
            base.FuncJudge = i => i > 100;
        }

        //public string[] eveltList;

        //public string Remark = null;
        //public string Spicy { get; set; }
        public override void SetOilTemperature(int temperature)
        {
            //if (temperature >=base.temperature)
            if (FuncJudge.Invoke(temperature))
            {
                base.StirFryInvoke();
            }
        }

        protected override void ShowUniSkillCore()
        {
            this.LikeLiquor();
        }

        public void LikeLiquor()
        {
            Console.WriteLine("Shandong people like drink liquor.");
        }

        public event Action MarianteChicken = () => Console.WriteLine("Mariante chicken");
        public event Action PutGarlic = () => Console.WriteLine("put garlic in");
        public event Action ThickenJuices;

        //This is basic mode of design framework. Alowed the client to customerise the actions.
        public void ShandongCooking()
        {
            this.Prologue();
            this.MarianteChicken?.Invoke(); //If MarianteChicken is not null, then invoke it.
            this.PutGarlic?.Invoke();      
            this.ThickenJuices?.Invoke();
            this.Closure();
            this.Charge();
        }

        public override void PutGingerIn()
        {
            LogHelper.WriteLogAndConsole($"{this.Chief} put ginger in pot");
        }

        public override void PutLeeksIn()
        {
            LogHelper.WriteLogAndConsole($"{this.Chief} put leeks in pot");
        }

        public override void PutChickenIn()
        {
            LogHelper.WriteLogAndConsole($"{this.Chief} put chicken in pot");
        }

        public void Charge()
        {
            LogHelper.WriteLogAndConsole($"The price for the Sichuan Chicken is {new Random().Next(10, 15)} ");
        }

        //public override void Prologue()
        //{
        //    LogHelper.WriteLogAndConsole($"{this.Chief} is starting to cook ");
        //}
    }
}
