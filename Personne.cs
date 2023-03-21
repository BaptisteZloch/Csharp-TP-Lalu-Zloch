public class Personne
{
    public string Nom { get; set; } = string.Empty;
    public int Age { get; set; }

    public string Hello(bool isLowercase)
    {
        var message = $"Hello {Nom}, you are {Age}";
        return isLowercase ? message.ToLower() : message.ToUpper();
    }
}
