using System;

namespace Application
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int error = 0;
			while (error == 0)
			{
				try
				{
					var cipher = new CaesarCipher();
					Console.Write("Введите текст: ");
					var message = Console.ReadLine();
					Console.Write("Введите ключ: ");
					var secretKey = Convert.ToInt32(Console.ReadLine());
					if (secretKey == null)
					{
						secretKey = 3;
					}
					var encryptedText = cipher.Encrypt(message, secretKey);
					Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
					Console.WriteLine("Расшифрованное сообщение: {0}", cipher.Decrypt(encryptedText, secretKey));
				}
				catch (FormatException exception)
				{
					Console.WriteLine(exception + "\n");
				}

				Console.ReadLine();
			}
		}
		public class CaesarCipher
		{
			const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

			private string CodeEncode(string text, int k)
			{
				//добавляем в алфавит маленькие буквы
				var fullAlfabet = alfabet + alfabet.ToLower();
				var letterQty = fullAlfabet.Length;
				var retVal = "";
				for (int i = 0; i < text.Length; i++)
				{
					var c = text[i];
					var index = fullAlfabet.IndexOf(c);
					if (index < 0)
					{
						//если символ не найден, то добавляем его в неизменном виде
						retVal += c.ToString();
					}
					else
					{
						var codeIndex = (letterQty + index + k) % letterQty;
						retVal += fullAlfabet[codeIndex];
					}
				}
				return retVal;
			}

			//шифрование текста
			public string Encrypt(string plainMessage, int key)
			=> CodeEncode(plainMessage, key);

			//дешифрование текста
			public string Decrypt(string encryptedMessage, int key)
			=> CodeEncode(encryptedMessage, -key);
		}
	}
}