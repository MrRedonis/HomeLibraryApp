using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Enums
{
    public enum LibraryItemType
    {
        [Display(Name = "Książka")]
        Book = 1,
        [Display(Name = "Magazyn")]
        Magazine = 2,
        [Display(Name = "Film")]
        Movie = 3,
        [Display(Name = "Album")]
        MusicAlbum = 4,
        [Display(Name = "Audiobook")]
        Audiobook = 5,
        [Display(Name = "Gra planszowa")]
        BoardGame = 6,
        [Display(Name = "Inne")]
        Other = 7
    }
}
