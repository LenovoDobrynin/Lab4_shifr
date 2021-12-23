using System;

//Атбаш
public class Atbash
{
    //алфавит языка
    private const string alphabet = "abcdefghijklmnopqrstuvwxyz";

    //метод для переворачивания строки
    private string Reverse(string inputText)
    {
        //переменная для хранения результата
        var reversedText = string.Empty;
        foreach (var s in inputText)
        {
            //добавляем символ в начало строки
            reversedText = s + reversedText;
        }

        return reversedText;
    }

    //метод шифрования/дешифрования
    private string EncryptDecrypt(string text, string symbols, string cipher)
    {
        //переводим текст в нижний регистр
        text = text.ToLower();

        var outputText = string.Empty;
        for (var i = 0; i < text.Length; i++)
        {
            //поиск позиции символа в строке алфавита
            var index = symbols.IndexOf(text[i]);
            if (index >= 0)
            {
                //замена символа на шифр
                outputText += cipher[index].ToString();
            }
        }

        return outputText;
    }

    //шифрование текста
    public string EncryptText(string plainText)
    {
        return EncryptDecrypt(plainText, alphabet, Reverse(alphabet));
    }

    //расшифровка текста
    public string DecryptText(string encryptedText)
    {
        return EncryptDecrypt(encryptedText, Reverse(alphabet), alphabet);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Атбаш шифрование");
        var atbash = new Atbash();
        Console.Write("Введите текст сообщения: ");
        var message = Console.ReadLine();
        var encryptedMessage = atbash.EncryptText(message);
        Console.WriteLine("Зашифрованное сообщение: {0}", encryptedMessage);
        var decryptedMessage = atbash.DecryptText(encryptedMessage);
        Console.WriteLine("Расшифрованное сообщение: {0}", decryptedMessage);
        Console.ReadLine();
    }
}