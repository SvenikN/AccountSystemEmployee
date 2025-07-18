using System;
using System.Collections.Generic;

namespace AccountingSystem.Repositories
{
  public interface IEmployeeManager<TEmployee>
  {
    /// <summary>
    /// Сформировать весь список сотрудников.
    /// </summary>
    /// <returns>Список сотрудников.</returns>
    List<TEmployee>? GetAllEmployee();

    /// <summary>
    /// Добавление нового сотрудника.
    /// </summary>
    /// <param name="employee">Данные сотрудника.</param>
    void AddEmployee(TEmployee employee);

    /// <summary>
    /// Получение информации о сотруднике по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns>Данные сотрудника.</returns>
    List<TEmployee>? GetEmployeeByName(string name);

    /// <summary>
    /// Получение информации о сотруднике по ID.
    /// </summary>
    /// <param name="id">ID сотрудника.</param>
    /// <returns>Данные сотруднкиа.</returns>
    TEmployee GetEmployeeById(int id);

    /// <summary>
    /// Обновление данных сотрудника.
    /// </summary>
    /// <param name="employee">Новые данные.</param>
    /// <param name="id">ID сортрудника.</param>
    void UpdateEmployee(TEmployee employee, int id);

    /// <summary>
    /// Удаление данных сотрудника.
    /// </summary>
    /// <param name="employee">Данные сотрудника которого нужно удалить.</param>
    void DeleteEmployee(int id);
  }
}
