using Common;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Immutable;

namespace Business.QueryTasks
{
	public abstract class AbstractBusinessTaskErrors
	{
		private readonly List<CommonErrorData> _errors;
		public ImmutableList<CommonErrorData> Errors => _errors.ToImmutableList();
		public bool HasErrors => Errors.Any();

		protected void AddError(string fieldName, string? fieldValue, string errorMsg)
		{
			_errors.Add(new CommonErrorData { FieldName = fieldName, FieldValue = fieldValue, ErrorDetails = errorMsg });
		}

	}
}
