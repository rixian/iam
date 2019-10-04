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
        public static async Task<Result<ICollection<Tenant>>> ListTenantsResultAsync(this IIamClient iamClient, string subjectId = null, System.Threading.CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            HttpResponseMessage response = await iamClient.ListTenantsHttpResponseAsync(subjectId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<Tenant>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IIamClient)}.{nameof(ListTenantsResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>Create Tenant.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="request">The request body.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<Result<Tenant>> CreateTenantResultAsync(this IIamClient iamClient, CreateTenantRequest request, System.Threading.CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            HttpResponseMessage response = await iamClient.CreateTenantHttpResponseAsync(request, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return await response.DeserializeJsonContentAsync<Tenant>().ConfigureAwait(false);
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IIamClient)}.{nameof(CreateTenantResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>Get Tenant.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<Result<Tenant>> GetTenantResultAsync(this IIamClient iamClient, Guid tenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            HttpResponseMessage response = await iamClient.GetTenantHttpResponseAsync(tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return await response.DeserializeJsonContentAsync<Tenant>().ConfigureAwait(false);
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IIamClient)}.{nameof(GetTenantResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>List Accounts.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<Result<object>> ListAccountsResultAsync(this IIamClient iamClient, System.Threading.CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            HttpResponseMessage response = await iamClient.ListAccountsHttpResponseAsync(cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return await response.DeserializeJsonContentAsync<Tenant>().ConfigureAwait(false);
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IIamClient)}.{nameof(ListAccountsResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>Check Member Users.</summary>
        /// <param name="iamClient">The IamClient to use.</param>
        /// <param name="request">The request body with values to check for tenant access.</param>
        /// <param name="tenantId">The tenant ID to check access.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public static async Task<Result<CheckTenantAccessResponse>> CheckTenantAccessResultAsync(this IIamClient iamClient, CheckTenantAccessRequest request, Guid tenantId, System.Threading.CancellationToken cancellationToken = default)
        {
            if (iamClient is null)
            {
                throw new ArgumentNullException(nameof(iamClient));
            }

            HttpResponseMessage response = await iamClient.CheckTenantAccessHttpResponseAsync(request, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return await response.DeserializeJsonContentAsync<CheckTenantAccessResponse>().ConfigureAwait(false);
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IIamClient)}.{nameof(CheckTenantAccessResultAsync)}").ConfigureAwait(false);
                }
            }
        }
    }
}
