using ApiBitirmeProjesi.Models.Entities;
using System.Security.Cryptography.Xml;

namespace ApiBitirmeProjesi.Models.DTOs;

public class CategoryCreateDTO
{
    // Bu sınıf, bir kategori oluşturma işlemi için kullanılan veri transfer nesnesini (DTO) temsil eder.

    public string CategoryName { get; set; } = string.Empty;

}
