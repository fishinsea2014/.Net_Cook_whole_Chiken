using Common;
using CookChicken.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookChiken.Service
{
    public class CantoneseChicken: AbstractChiefs, ICharge
    {
        public CantoneseChicken()
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
            this.LikeSugar();
        }

        public void LikeSugar()
        {
            Console.WriteLine("Cantonese chief is good at using sugar.");
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
