// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
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
        public static async Task<ICollection<Tenant>> ListTenantsAsync(this IIamClient iamClient, string subjectId = null, System.Threading.CancellationToken cancellationToken = default)
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
        public static async Task<Tenant> CreateTenantAsync(this IIamClient iamClient, CreateTenantRequest request, System.Threading.CancellationToken cancellationToken = default)
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
        public static async Task<Tenant> GetTenantAsync(this IIamClient iamClient, Guid tenantId, System.Threading.CancellationToken cancellationToken = default)
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
        public static async Task<object> ListAccountsAsync(this IIamClient iamClient, System.Threading.CancellationToken cancellationToken = default)
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

        /// <summary>Check Member Users.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="request">The request body with values to check for tenant access.</param>
        /// <param name="tenantId">The tenant ID to check access.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<CheckTenantAccessResponse> CheckTenantAccessAsync(this IIamClient iamClient, CheckTenantAccessRequest request, Guid tenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            Result<CheckTenantAccessResponse> result = await iamClient.CheckTenantAccessResultAsync(request, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }
    }
}
