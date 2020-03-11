// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Client interface for the Rixian IAM Api.
    /// </summary>
    public interface IIamClient
    {
        /// <summary>List Tenants.</summary>
        /// <param name="subjectId">The ID of the subject (e.g. user ID).</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListTenantsHttpResponseAsync(string subjectId = null, CancellationToken cancellationToken = default);

        /// <summary>Create Tenant.</summary>
        /// <param name="request">The request body.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CreateTenantHttpResponseAsync(CreateTenantRequest request, CancellationToken cancellationToken = default);

        /// <summary>Get Tenant.</summary>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetTenantHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>List Accounts.</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListAccountsHttpResponseAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Grants a given object access rights to the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant id to grant access.</param>
        /// <param name="subjectId">The object that requires graned permissions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<HttpResponseMessage> GrantAccessToTenantHttpResponseAsync(Guid tenantId, string subjectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if the given object is allowed access to the tenant.
        /// </summary>
        /// <param name="request">The object that requires a permission check.</param>
        /// <param name="tenantId">The tenant id to check against.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>True if access is allowed, otherwise false.</returns>
        Task<HttpResponseMessage> IsAllowedAccessToTenantHttpResponseAsync(AclCheckRequest request, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Revokes a given object access rights to the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant id to revoke access.</param>
        /// <param name="subjectId">The object that requires revoked permissions.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<HttpResponseMessage> RemoveAccessToTenantHttpResponseAsync(Guid tenantId, string subjectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about the currently logged in user.
        /// </summary>
        /// <param name="subjectId">Optional user id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<HttpResponseMessage> GetMyDetailsHttpResponseAsync(string subjectId = null, CancellationToken cancellationToken = default);
    }
}
