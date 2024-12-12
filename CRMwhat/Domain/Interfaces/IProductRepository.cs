using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Получить продукт по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор продукта (Guid).</param>
        /// <returns>Возвращает продукт или null, если продукт не найден.</returns>
        Product GetById(Guid id);

        /// <summary>
        /// Получить все продукты.
        /// </summary>
        /// <returns>Список всех продуктов.</returns>
        List<Product> GetAll();

        /// <summary>
        /// Добавить новый продукт.
        /// </summary>
        /// <param name="product">Сущность продукта.</param>
        void Add(Product product);

        /// <summary>
        /// Обновить продукт.
        /// </summary>
        /// <param name="product">Сущность продукта с обновлёнными данными.</param>
        void Update(Product product);

        /// <summary>
        /// Удалить продукт по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор продукта (Guid).</param>
        void Delete(Guid id);
    }
}
