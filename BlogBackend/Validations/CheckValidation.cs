using BlogBackend.Exceptions;
namespace BlogBackend.Validations
{
    public static class CheckValidation
    {
        public static string CheckStringValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationException("Giriş alanı boş geçilemez!");

            return value.Trim();
        }

        public static int CheckIdValue(int id)
        {
            if (id <= 0)
                throw new ValidationException("Lütfen id değerini 0'dan büyük değer giriniz!");

            return id;
        }


    }
}
