using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	[NotMapped]
	public class User : IdentityUser<int>, IEntityBase
	{
		public User()
		{
			UserRoles = new HashSet<UserRole>();
		}

		// public int UserId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? FinishedDate { get; set; }
		public byte[] Version { get; set; }
		public int? PersonId { get; set; }
		public bool Deleted { get; set; }
		public int? CompanyId { get; set; }
		public string? PasswordQuestion { get; set; }
		public string? PasswordAnswer { get; set; }
		public int ReceivesFiles { get; set; }
		public DateTime PasswordModificationDate { get; set; }
		public int? EmployeeId { get; set; }
		public int? RegionId { get; set; }
		public bool IsTemporaryPassword { get; set; }
		public bool IsLockedOut { get; set; }
		public DateTime? LastLockoutDate { get; set; }
		public int FailedPasswordAttemptCount { get; set; }
		public string? Token { get; set; }
		public int TwoFactorAuthSetupStatus { get; set; }
		public bool IsMfaLockedOut { get; set; }
		public int FailedMfaAttemptCount { get; set; }
		public string? LastDeviceCodeUsed { get; set; }
		public string? CurrentMfaDeviceToken { get; set; }
		public int FailedAccountVerificationAttempts { get; set; }
		public int PasswordResetAttemptCount { get; set; }

		public virtual Employee? Employee { get; set; }
		public virtual Person? Person { get; set; }
		public virtual Company? Company { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
