using PayCommands.Economy;
using Rocket.API.Collections;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCommands
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance { get; private set; }
        private IEconomyProvider economyProvider { get; set; }
        protected override void Load()
        {
            Instance = this;

            R.Commands.OnExecuteCommand += Commands_OnExecuteCommand;

            if (Configuration.Instance.UseEconomy)
            {
                economyProvider = new UconomyEconomyProvider();
            }
            else
            {
                economyProvider = new ExperienceEconomyProvider();
            }

            Rocket.Core.Logging.Logger.Log($"Plugin By Margarita#8172", ConsoleColor.Cyan);
        }

        private void Commands_OnExecuteCommand(Rocket.API.IRocketPlayer player, Rocket.API.IRocketCommand command, ref bool cancel)
        {

            var data = Configuration.Instance.Commands.Find(x => x.Name.ToLower() == command.Name.ToLower());

            if (data != null)
            {
                if (economyProvider.GetBalance(player.Id) >= data.Cost)
                {
                    economyProvider.IncrementBalance(player.Id, data.Cost);
                    UnturnedChat.Say(player, Translate("command", command.Name.ToUpper(), data.Cost));
                    cancel = false;
                }
                else
                {
                    UnturnedChat.Say(player, Translate("nomoney"));
                    cancel = true;
                }
            }


        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                TranslationList list = new TranslationList();
                list.Add("nomoney", "No tienes suficiente dinero para ejecutar este comando");
                list.Add("command", "Has comprado el comando {0} por {1} $");
                return list;
            }
        }

        protected override void Unload()
        {
            R.Commands.OnExecuteCommand -= Commands_OnExecuteCommand;
        }
    }
}
