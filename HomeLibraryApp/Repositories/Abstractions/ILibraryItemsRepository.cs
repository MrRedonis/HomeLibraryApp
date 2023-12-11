using HomeLibraryApp.Models;
using HomeLibraryApp.Models.ViewModels;

namespace HomeLibraryApp.Repositories.Abstractions
{
    public interface ILibraryItemsRepository
    {
        IList<LibraryItem> GetLibraryItems();
        void AddLibraryItem(CreateLibraryItemViewModel model);
		LibraryItem GetLibraryItemById(int id);
        void UpdateLibraryItem(EditLibraryItemViewModel model);
        void Delete(LibraryItem model);
    }
}
