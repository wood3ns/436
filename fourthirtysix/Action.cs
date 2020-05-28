using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourthirtysix
{

    public class GameActionEventArgs : EventArgs
    {
        public GameActionEventArgs(string s)
        {
            response = s;
        }
        private string response;

        public string Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class GameAction
    {
        public List<string> Trigger = new List<string>();
        public string Response;

        public GameAction(string trigger, string response)
        {
            Trigger.Add(trigger);
            Response = response;
        }

        public bool TryAction(string trigger)
        {
            foreach (string trig in Trigger) 
            {
                if (trig.ToUpper() == trigger.ToUpper())
                {
                    OnGameActionTriggered(new GameActionEventArgs(Response));
                    return true;
                }
            }
            return false;
        }

        public event EventHandler<GameActionEventArgs> GameActionTriggered;

        protected virtual void OnGameActionTriggered(GameActionEventArgs e) 
        {
            GameActionTriggered?.Invoke(this, e);
        }
    }
}
