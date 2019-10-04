// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Polly;
    using Rixian.Extensions.Http.Client;

    /// <summary>
    /// Client for the Rixian IAM Api.
    /// </summary>
    public class IamClient : IIamClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="IamClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient to use for all requests.</param>
        public IamClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets or sets the policy for the GetTenant http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> GetTenantPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListTenants http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> ListTenantsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the CreateTenant http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> CreateTenantPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListAccounts http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> ListAccountsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the CheckTenantAccess http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> CheckTenantAccessPolicy { get; set; }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetTenantHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}")
                .ReplaceToken("{tenantId}", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetTenantAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetTenantPolicy).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListTenantsHttpResponseAsync(string subjectId = null, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants")
                .SetQueryParam("userId", subjectId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListTenantsAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListTenantsPolicy).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CreateTenantHttpResponseAsync(CreateTenantRequest request, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants")
                .ToRequest()
                .WithHttpMethod().Post()
                .WithContentJson(request)
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewCreateTenantAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CreateTenantPolicy).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListAccountsHttpResponseAsync(CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("accounts")
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListAccountsAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListAccountsPolicy).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CheckTenantAccessHttpResponseAsync(CheckTenantAccessRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/checkMemberUsers")
                .ReplaceToken("{tenantId}", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithContentJson(request)
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewCheckTenantAccessAsync(requestBuilder).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CheckTenantAccessPolicy).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Optional method for configurings the HttpRequestMessage before sending the call to GetTenant.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetTenantAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configurings the HttpRequestMessage before sending the call to ListTenants.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListTenantsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configurings the HttpRequestMessage before sending the call to CreateTenant.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCreateTenantAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configurings the HttpRequestMessage before sending the call to ListAccounts.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListAccountsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configurings the HttpRequestMessage before sending the call to CheckTenantAccess.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCheckTenantAccessAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        private async Task<HttpResponseMessage> SendRequestWithPolicy(IHttpRequestMessageBuilder requestBuilder, IAsyncPolicy<HttpResponseMessage> policy = null, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = requestBuilder.Request;
            using (request)
            {
                Func<Task<HttpResponseMessage>> sendRequest = () => this.httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                if (policy != null)
                {
                    HttpResponseMessage response = await policy.ExecuteAsync(sendRequest).ConfigureAwait(false);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = await sendRequest().ConfigureAwait(false);
                    return response;
                }
            }
        }
    }
}
