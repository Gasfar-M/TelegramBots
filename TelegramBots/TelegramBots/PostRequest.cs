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
				var pars = new NameValueCollection();
				byte[] response;
				if (fields != null)
				{
					foreach (var field in fields)
					{
						pars.Add(field.Key, field.Value);
					}
				}
				else
					pars.Add("", "");
				response = webClient.UploadValues(url, "POST", pars);
				var result = System.Text.Encoding.UTF8.GetString(response);
				return result;
			}
		}
	}
}
