using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagements.ViewModels
{
    public class BookEditViewModel : BookCreateViewModel
    {
        public int Id { get; set; }
        public string ExixtingPhotoPath { get; set; }
    }
}
