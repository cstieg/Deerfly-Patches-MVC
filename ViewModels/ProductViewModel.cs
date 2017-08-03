using Deerfly_Patches.Models;
using System.Web;

namespace Deerfly_Patches.ViewModels
{
    public class ProductViewModel : Product
    {
        HttpPostedFileBase ImageUpload { get; set; }
    }
}