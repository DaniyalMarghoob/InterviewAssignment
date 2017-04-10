using Appccelerate.StateMachine.Machine;
using System;
using System.Collections.Generic;

namespace InterviewAssignment
{

    /// <summary>
    /// Provides way to customize state reporting.
    /// 
    /// By default you cannot get container of states from Appccelerate state machine.
    /// This class can be used for that. Also it has StateToString method to enable
    /// printing hierarchical states.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    /// <typeparam name="TEvent"></typeparam>
    public class CustomStateMachineReporter<TState, TEvent> : IStateMachineReport<TState, TEvent>
            where TState : IComparable
    where TEvent : IComparable

    {
        IEnumerable<IState<TState, TEvent>> myStates;

        public IEnumerable<IState<TState, TEvent>> States
        {
            get
            {
                return myStates;
            }
        }

        public void Report(string name, IEnumerable<IState<TState, TEvent>> states, Initializable<TState> initialStateId)
        {
            myStates = states;
        }

        public string StateToString(TState state, string separator = ".")
        {

            //Your assignment is here!
            //Tip: You find state machine hierarchy on States property (or myStates field). 
            //You should go through the states and print that on what hierarchy path the current state
            //is found. So if state is Initializing this method should return "Down.Initializing" because
            //"Initializing" is substate of "Down".
//            throw new NotImplementedException();

		    string result = "";
            int i = -1;//just to get index from hierarchy path 
            Console.WriteLine("\nCurrent State: " + state.ToString());
            Console.WriteLine("Hierarchy path:");

            foreach (IState<TState, TEvent> t_orderState in myStates) {//loop over mystates list
                i++;
                Console.WriteLine("\t" + t_orderState.ToString()); 
                if (t_orderState.ToString().Equals(state.ToString())) //if state matches then finalizing state
                    {
                        
                        Robot.State robotState = (Robot.State)i;
                        result = robotState + separator + state.ToString();

                    if (state.ToString().Equals("PowerOn"))
                        {
                            Robot.State zeroState = (Robot.State)0;
                            result = zeroState + separator + robotState + separator + state.ToString();
                        }

                }
            }

            return result;
        }
    }
}
