// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Extensions.Errors;
    using Rixian.Extensions.Http.Client;

    /// <summary>
    /// Extensions for the Rixian IAM api client.
    /// </summary>
    public static partial class IamClientExtensions
    {
        /// <summary>List Tenants.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="subjectId">The ID of the subject (e.g. user ID).</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<ICollection<Tenant>> ListTenantsAsync(this IIamClient iamClient, string subjectId = null, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<ICollection<Tenant>> result = await iamClient.ListTenantsResultAsync(subjectId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>Create Tenant.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="request">The request body.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<Tenant> CreateTenantAsync(this IIamClient iamClient, CreateTenantRequest request, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<Tenant> result = await iamClient.CreateTenantResultAsync(request, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>Get Tenant.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<Tenant> GetTenantAsync(this IIamClient iamClient, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<Tenant> result = await iamClient.GetTenantResultAsync(tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>List Accounts.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<object> ListAccountsAsync(this IIamClient iamClient, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<object> result = await iamClient.ListAccountsResultAsync(cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Checks if the given subject is allowed access to the tenant.
        /// </summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="request">The subject that requires a permission check.</param>
        /// <param name="tenantId">The tenant id to check against.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<AclCheckResponse> IsAllowedAccessToTenantAsync(this IIamClient iamClient, AclCheckRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<AclCheckResponse> result = await iamClient.IsAllowedAccessToTenantResultAsync(request, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Checks if the given subject is allowed access to the tenant.
        /// </summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="tenantId">The tenant id to check against.</param>
        /// <param name="subjectId">The subject that requires ACL checks permissions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<bool> IsAllowedAccessToTenantAsync(this IIamClient iamClient, Guid tenantId, string subjectId, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<bool> result = await iamClient.IsAllowedAccessToTenantResultAsync(tenantId, subjectId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Grants a given subject access rights to the tenant.
        /// </summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="tenantId">The tenant id to grant access.</param>
        /// <param name="subjectId">The subject that requires granted permissions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task GrantAccessToTenantAsync(this IIamClient iamClient, Guid tenantId, string subjectId, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result result = await iamClient.GrantAccessToTenantResultAsync(tenantId, subjectId, cancellationToken).ConfigureAwait(false);

            if (result.IsError)
            {
                throw ApiException.Create(result.Error);
            }
        }

        /// <summary>
        /// Revokes a given subject access rights to the tenant.
        /// </summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="tenantId">The tenant id to revoke access.</param>
        /// <param name="subjectId">The subject that requires revoked permissions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task RemoveAccessToTenantAsync(this IIamClient iamClient, Guid tenantId, string subjectId, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result result = await iamClient.RemoveAccessToTenantResultAsync(tenantId, subjectId, cancellationToken).ConfigureAwait(false);

            if (result.IsError)
            {
                throw ApiException.Create(result.Error);
            }
        }

        /// <summary>
        /// Get information about the currently logged in user.
        /// </summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="subjectId">Optional user id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<UserInfoResponse> GetMyDetailsAsync(this IIamClient iamClient, string subjectId, CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<UserInfoResponse> result = await iamClient.GetMyDetailsResultAsync(subjectId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }
    }
}
