﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textadventure
{
    internal class OrcBattle
    {
        private static Scene[] _scenes = {
            new Scene(new Option[]{
                new Option(OptionIdentifier.FIGHT, "Du verfehlst.#Du triffst den Ork, doch dieser kämpft unbeirrt weiter.", new string[]{"BATTLE_FAIL1", "BATTLE_HIT1"}, new string[]{"Ork", "Monster"}),
                new Option(OptionIdentifier.FLEE, "Du fliehst dorthin wo du hergekommen bist", new string[]{"#START#"})
            }, "BATTLE_START","Auf deinem Weg greift dich plötzlich ein Ork an.",
                "$orcAmbush"),
            new Scene(new Option[]{
                new Option(OptionIdentifier.GO, "Du gehst einen Schritt zurück und der Ork kommt aus seiner Balance#Der Ork trifft dich mit seinen tödlichen Klingen und du stirbst.", new string[]{"BATTLE_HIT1", "BATTLE_DEATH"}, new string[]{"Zurück", "Deckung"}),
                new Option(OptionIdentifier.FLEE, "Du fliehst dorthin wo du hergekommen bist", new string[]{"#START#"})
            }, "BATTLE_FAIL1","Wütend attackiert dich der Ork und holt mit seinen großen Klingen aus um dich zu töten."),
            new Scene(new Option[]{
                new Option(OptionIdentifier.FIGHT, "Du besiegst den Ork und gehst weiter.#Du schlägst den Ork und verfehlst. Nun holt er mit seinen Klingen aus und droht dich zu zerquetschen.#Du triffst den Ork, doch dieser kämpft unbeirrt weiter.", new string[]{"#END#", "BATTLE_FAIL1", "BATTLE_HIT1"}, new string[]{"Ork", "Monster"}),
                new Option(OptionIdentifier.FLEE, "Du fliehst dorthin wo du hergekommen bist", new string[]{"#START#"})
            }, "BATTLE_HIT1","Jetzt ist die Gelegenheit da, der Ork ist angeschlagen."),
            new Scene(new Option[]{
                new Option(OptionIdentifier.GO, "Während deine Leiche mit der Natur verschmilzt, steigt dein Geist zu einer höheren Ebene auf, wo dir eine Stimme etwas sagt:", new string[]{"END_THANKS"}, new string[]{"Ende", "Schluss"})
            }, "BATTLE_DEATH","Der Ork erschlägt dich und plündert deine Überreste. Tippe 'Gehe zu Ende' um dein Abenteuer zu beenden.")
        };
        public static Scene[] getScenes(string startScene, string endScene)
        {
            foreach (Scene scene in _scenes)
            {
                foreach(Option option in scene.Options)
                {
                    for (int i = 0; i < option.NextScene.Length; i++)
                    {
                        if (option.NextScene[i] == "#START#")
                        {
                            option.NextScene[i] = startScene;
                        }
                        else if (option.NextScene[i] == "#END#")
                        {
                            option.NextScene[i] = endScene;
                        }
                    }
                }
            }
            return _scenes;
        }
    }
}
