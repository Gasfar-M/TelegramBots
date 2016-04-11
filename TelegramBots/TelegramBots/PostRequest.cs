using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBots
{
	public class PostRequest
	{
		public string MakePostRequest(string botToken, string methodName, Dictionary<string, string> fields)
		{
			var url = "https://api.telegram.org/bot" + botToken + "/" + methodName;

			using (var webClient = new WebClient())
			{
				// Создаём коллекцию параметров
				var pars = new NameValueCollection();

				// Добавляем необходимые параметры в виде пар ключ, значение
				foreach (var field in fields)
				{
					pars.Add(field.Key, field.Value);
				}
				
				// Посылаем параметры на сервер
				// Может быть ответ в виде массива байт
				var response = webClient.UploadValues(url, "POST", pars);

				var result = System.Text.Encoding.UTF8.GetString(response);
				return result;
			}
		}
	}
}
