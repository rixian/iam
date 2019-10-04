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

        /// <summary>Check Member Users.</summary>
        /// <param name="request">The request body with values to check for tenant access.</param>
        /// <param name="tenantId">The tenant ID to check access.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CheckTenantAccessHttpResponseAsync(CheckTenantAccessRequest request, Guid tenantId, CancellationToken cancellationToken = default);
    }
}
