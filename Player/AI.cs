namespace FinalBattle
{
    public class AI : Player
    {
        public AI(string name) : base(name) { }

        public override void Turn(Party partyTurn, Party enemyParty)
        {
            foreach(Character character in partyTurn.Members)
            {
                IAction action = ChooseAction(character, partyTurn, enemyParty);
                action.Execute(character, Input.Targets(character, ));
            }
        }

        public override IAction ChooseAction(Character charTurn, Party partyTurn, Party enemyParty)
        {
            
        }
    }
}
