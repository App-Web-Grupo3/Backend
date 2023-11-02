namespace UniqueTrip.Response
{
    public class FavoritesResponse
    {
        public int Id { get; set; }
        public int Tourist_id { get; set; }
        public int Activities_id { get; set; }
        public DateTime DateCreated { get; set; }

        // Opcional: Si deseas agregar más campos relacionados con Favorites, puedes hacerlo aquí.
    }
}