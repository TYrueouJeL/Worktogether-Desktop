using W2G.EF;

namespace W2G.CSNL._Controllers
{
    public class StateMenu
    {
        public static StateEntity GenerateState(string stateValue)
        {
            WtgContext? context = new WtgContext();
            StateEntity state = new StateEntity();

            state.State = stateValue;
            
            context.Add(state);
            context.SaveChanges();

            return state;
        }

        public static void SearchAndShowState(string stateValue)
        {
            WtgContext? context = new WtgContext();
            StateEntity? state = context.State.FirstOrDefault(item => item.State == stateValue);
            Console.WriteLine($"State : {state.State}");
        }

        public static void UpdateState(StateEntity state, string stateValue)
        {
            WtgContext? context = new WtgContext();
            StateEntity? stateToUpdate = context.State.FirstOrDefault(item => item.Id == state.Id);
            if (stateToUpdate != null)
            {
                stateToUpdate.State = stateValue;
                context.SaveChanges();
            }
        }

        public static void DeleteState(StateEntity state)
        {
            WtgContext? context = new WtgContext();
            StateEntity? stateToDelete = context.State.FirstOrDefault(item => item.Id == state.Id);
            if (stateToDelete != null)
            {
                context.Remove(stateToDelete);
                context.SaveChanges();
            }
        }
    }
}
