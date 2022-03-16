using System;
using System.Collections.Generic;

namespace OkuruBot
{
    public interface IResponseEngine
    {
        bool ShouldRespond(string message);
        string GenerateResponse();
        string GenerateResponseToOkuru();
    }

    public class ResponseEngine : IResponseEngine
    {
        private readonly string[] _responses =
        {
            "Dude my class is just so bad",
            "Ele is honestly just worthless at pvp",
            "Jokes on you for trying to play shaman in arena",
            "Pvp as ele just feels so bad man",
            "im going enhance next phase, blizzard just hates ele shaman",
            "I dont know dude, war stomp is just so fucking busted",
            "bgs are just cancer",
            "I'd do some bgs. Just dont expect to win any because i'm playing with this gimp class",
            "blizzard just doesnt design gear for dps shaman",
            "resilience is such a horribly designed mechanic",
            "fuck the ping on this server, why did we transfer to a west coast server?",
            "Mace stun is so fucking broken, what a horrible mechanic",
            "even if I had like 700 resilience i'd still get like 2-shot by warriors",
            "Shamans are bad but like theres nothing more pathetic in a BG than a badly geared rogue",
            "itd be cool if they gave shaman like anything for pvp. Like their only tools are bloodlust and and fire ele, which they cant even us in arena.",
            "People who think shaman isn't that bad honestly just haven't spent much time playing the class.",
            "imagine healing an arena and your best healing spell is fucking lesser healing wave",
            "stormherald was a mistake",
            "I dont know why anyone would play heroes of the storm when league of legends and dota exist",
            "imagine having seed of corruption and losing to a shaman in dps"
        };

        public bool ShouldRespond(string message)
            => message.StartsWith("Okuru", StringComparison.OrdinalIgnoreCase);

        public string GenerateResponse()
        {
            var random = new Random();
            var index = random.Next(_responses.Length);
            return _responses[index];
        }

        public string GenerateResponseToOkuru()
        {
            //TODO
            var random = new Random();
            var index = random.Next(_responses.Length);
            return _responses[index];
        }
    }
}