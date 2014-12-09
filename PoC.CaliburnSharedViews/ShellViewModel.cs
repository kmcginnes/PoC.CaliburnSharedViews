using Caliburn.Micro;

namespace PoC.CaliburnPopup
{
    public class ShellViewModel : Conductor<TabViewModel>.Collection.OneActive, IShell
    {
        public ShellViewModel()
        {
            var shared = new SharedViewModel();

            Items.AddRange(new []
            {
                new TabViewModel
                {
                    DisplayName = "Tab 1",
                    Shared = shared,
                }, 
                new TabViewModel
                {
                    DisplayName = "Tab 2",
                    Shared = shared,
                },
            });

            foreach (var item in Items)
            {
                item.Shared.ConductWith(item);
            }
        }
    }
}