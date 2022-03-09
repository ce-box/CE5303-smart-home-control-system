﻿using Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Services.Contracts
{
    public interface IAuthService : IDisposable
    {
        String GetUserName(ClaimsPrincipal principal);
        String GetUserId(ClaimsPrincipal principal);
        Task<User> GetUserAsync(ClaimsPrincipal principal);
        Task<String> GenerateConcurrencyStampAsync(User user);
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> DeleteAsync(User user);
        Task<User> FindByIdAsync(String userId);
        Task<User> FindByNameAsync(String userName);
        Task<IdentityResult> CreateAsync(User user, String password);
        String NormalizeName(String name);
        String NormalizeEmail(String email);
        Task UpdateNormalizedUserNameAsync(User user);
        Task<String> GetUserNameAsync(User user);
        Task<IdentityResult> SetUserNameAsync(User user, String userName);
        Task<String> GetUserIdAsync(User user);
        Task<Boolean> CheckPasswordAsync(User user, String password);
        Task<Boolean> HasPasswordAsync(User user);
        Task<IdentityResult> AddPasswordAsync(User user, String password);
        Task<IdentityResult> ChangePasswordAsync(User user, String currentPassword, String newPassword);
        Task<IdentityResult> RemovePasswordAsync(User user);
        Task<String> GetSecurityStampAsync(User user);
        Task<IdentityResult> UpdateSecurityStampAsync(User user);
        Task<String> GeneratePasswordResetTokenAsync(User user);
        Task<IdentityResult> ResetPasswordAsync(User user, String token, String newPassword);
        Task<User> FindByLoginAsync(String loginProvider, String providerKey);
        Task<IdentityResult> RemoveLoginAsync(User user, String loginProvider, String providerKey);
        Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo login);
        Task<IList<UserLoginInfo>> GetLoginsAsync(User user);
        Task<IdentityResult> AddClaimAsync(User user, Claim claim);
        Task<IdentityResult> AddClaimsAsync(User user, IEnumerable<Claim> claims);
        Task<IdentityResult> ReplaceClaimAsync(User user, Claim claim, Claim newClaim);
        Task<IdentityResult> RemoveClaimAsync(User user, Claim claim);
        Task<IdentityResult> RemoveClaimsAsync(User user, IEnumerable<Claim> claims);
        Task<IList<Claim>> GetClaimsAsync(User user);
        Task<IdentityResult> AddToRoleAsync(User user, String role);
        Task<IdentityResult> AddToRolesAsync(User user, IEnumerable<String> roles);
        Task<IdentityResult> RemoveFromRoleAsync(User user, String role);
        Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<String> roles);
        Task<IList<String>> GetRolesAsync(User user);
        Task<Boolean> IsInRoleAsync(User user, String role);
        Task<String> GetEmailAsync(User user);
        Task<IdentityResult> SetEmailAsync(User user, String email);
        Task<User> FindByEmailAsync(String email);
        Task UpdateNormalizedEmailAsync(User user);
        Task<String> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, String token);
        Task<Boolean> IsEmailConfirmedAsync(User user);
        Task<String> GenerateChangeEmailTokenAsync(User user, String newEmail);
        Task<IdentityResult> ChangeEmailAsync(User user, String newEmail, String token);
        Task<String> GetPhoneNumberAsync(User user);
        Task<IdentityResult> SetPhoneNumberAsync(User user, String phoneNumber);
        Task<IdentityResult> ChangePhoneNumberAsync(User user, String phoneNumber, String token);
        Task<Boolean> IsPhoneNumberConfirmedAsync(User user);
        Task<String> GenerateChangePhoneNumberTokenAsync(User user, String phoneNumber);
        Task<Boolean> VerifyChangePhoneNumberTokenAsync(User user, String token, String phoneNumber);
        Task<Boolean> VerifyUserTokenAsync(User user, String tokenProvider, String purpose, String token);
        Task<String> GenerateUserTokenAsync(User user, String tokenProvider, String purpose);
        void RegisterTokenProvider(String providerName, IUserTwoFactorTokenProvider<User> provider);
        Task<IList<String>> GetValidTwoFactorProvidersAsync(User user);
        Task<Boolean> VerifyTwoFactorTokenAsync(User user, String tokenProvider, String token);
        Task<String> GenerateTwoFactorTokenAsync(User user, String tokenProvider);
        Task<Boolean> GetTwoFactorEnabledAsync(User user);
        Task<IdentityResult> SetTwoFactorEnabledAsync(User user, Boolean enabled);
        Task<Boolean> IsLockedOutAsync(User user);
        Task<IdentityResult> SetLockoutEnabledAsync(User user, Boolean enabled);
        Task<Boolean> GetLockoutEnabledAsync(User user);
        Task<DateTimeOffset?> GetLockoutEndDateAsync(User user);
        Task<IdentityResult> SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd);
        Task<IdentityResult> AccessFailedAsync(User user);
        Task<IdentityResult> ResetAccessFailedCountAsync(User user);
        Task<Int32> GetAccessFailedCountAsync(User user);
        Task<IList<User>> GetUsersForClaimAsync(Claim claim);
        Task<IList<User>> GetUsersInRoleAsync(String roleName);
        Task<String> GetAuthenticationTokenAsync(User user, String loginProvider, String tokenName);
        Task<IdentityResult> SetAuthenticationTokenAsync(User user, String loginProvider, String tokenName, String tokenValue);
        Task<IdentityResult> RemoveAuthenticationTokenAsync(User user, String loginProvider, String tokenName);
        Task<String> GetAuthenticatorKeyAsync(User user);
        Task<IdentityResult> ResetAuthenticatorKeyAsync(User user);
        String GenerateNewAuthenticatorKey();
        Task<IEnumerable<String>> GenerateNewTwoFactorRecoveryCodesAsync(User user, Int32 number);
        Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(User user, String code);
        Task<Int32> CountRecoveryCodesAsync(User user);
        Task<Byte[]> CreateSecurityTokenAsync(User user);
        Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure = false);
        Task SignOutAsync();
    }
}
