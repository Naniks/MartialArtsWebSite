using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SportsStore.Components {
    public class NavigationMenuViewComponent : ViewComponent {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
