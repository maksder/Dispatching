using System.Net.Mime;
using Dispatching.Domain.Common;
using Microsoft.AspNetCore.Diagnostics;

namespace Dispatching.Service
{
	/// <summary>
	/// Представляет обработчик исключений.
	/// </summary>
	public static class ExceptionHandler
	{
		#region Public
		/// <summary>
		/// Обрабатывает ошибку во время выполнения запроса.
		/// </summary>
		/// <param name="context">Контекст запроса.</param>
		/// <returns>Задача обработки.</returns>
		public static async Task HandleAsync(HttpContext context)
		{
			context.Response.ContentType = MediaTypeNames.Text.Plain;

			var status = StatusCodes.Status500InternalServerError;
			var message = "Произошла ошибка";

			var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

			var error = exceptionHandlerPathFeature?.Error;

			switch (error)
			{
				case BusinessException be:
					status = StatusCodes.Status409Conflict;
					message = be.ErrorMessage;
					break;
				case EntityNotFoundException ef:
					status = StatusCodes.Status404NotFound;
					message = ef.ErrorMessage;
					break;
			}

			context.Response.StatusCode = status;
			await context.Response.WriteAsync(message);
			await context.Response.CompleteAsync();
		}
		#endregion
	}
}
