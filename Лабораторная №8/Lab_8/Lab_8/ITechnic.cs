namespace Lab_8
{
    /* 1. Создайте обобщенный интерфейс c операциями  добавить, удалить, просмотреть. */

    public interface ITechnic<T>
    {
        void Add(T item);
        void Delete(T item);
        void Show();
    }
}