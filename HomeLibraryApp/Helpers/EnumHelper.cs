using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeLibraryApp.Helpers
{
	public static class EnumHelper
	{
		public static string GetDisplayNameForEnum<TModel, TValue>(
			this IHtmlHelper<TModel> htmlHelper,
			TValue value) where TModel : class
		{
			var enumType = typeof(TValue);

			if (!enumType.IsEnum)
			{
				throw new ArgumentException("The provided type is not an enum");
			}

			var memberInfo = enumType.GetMember(value.ToString());

			if (memberInfo.Length > 0)
			{
				var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
				if (attributes.Length > 0)
				{
					return ((DisplayAttribute)attributes[0]).Name;
				}
			}

			return value.ToString();
		}
	}
}
