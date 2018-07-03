using Common;
using Common.AttributeExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookChicken.Interface
{
    public abstract class AbstractChiefs
    {
        [RemarkAttribute("Cook")]
        public string Chief { get; set; }
        public string Leeks { get; set; }
        public string Ginger { get; set; }
        public string ChickenDices { get; set; }

        protected int temperature = 120;
        protected Func<int, bool> FuncJudge = i => i>400;

        public event Action StirFry;

        public void Play()
        {
            LogHelper.WriteLogAndConsole("Cooking chicken is ready.");
        }
        public virtual void SetOilTemperature( int temperature)
        {
            //if (temperature >=this.temperature)  // use a variable
            if  (this.FuncJudge.Invoke(temperature))
            {
                this.StirFryInvoke();
            }
        }

        protected void StirFryInvoke()
        {
            this.StirFry?.Invoke();
        }

        public void ShowUniSkill()
        {
            LogHelper.WriteLogAndConsole("Unique skill start");
            this.ShowUniSkillCore();
            LogHelper.WriteLogAndConsole("Unique skill complete");
        }

        protected abstract void ShowUniSkillCore();

        public abstract void PutLeeksIn();

        public abstract void PutGingerIn();

        public abstract void PutChickenIn();

        public virtual void Prologue()
        {
            LogHelper.WriteLogAndConsole("Cooking chicken dices start...");
        }

        public virtual void Closure()
        {
            LogHelper.WriteLogAndConsole("Cooking chicken dices finished.");
        }
    }
}
