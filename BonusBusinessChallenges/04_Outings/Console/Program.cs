using System;
using _Outings.Repositories;

namespace _Outings.Console
{
    public class Program
    {
        public static void Main()
        {
            OutingRepository uiRepo = new OutingRepository();
            ProgramUI ui = new ProgramUI(uiRepo);
            uiRepo.AddInitialOuting();
            ui.Run();
        }
        
    }
}
