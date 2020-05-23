// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Net.Http;
    using System.Security.Authentication;
    using Rixian.Extensions.Tokens;
    using Rixian.Iam;

    /// <summary>
    /// Extensions for adding IIamClient to the DI container.
    /// </summary>
    public static class RixianIamClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the IIamClient with the DI container.
        /// </summary>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="options">Configuration options for this client.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddIamClient(this IServiceCollection serviceCollection, IamClientOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.TokenClientOptions is null)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            // Configure the HttpClient for use by the ITokenClient.
            serviceCollection.AddHttpClient(IamClientOptions.IamTokenClientHttpClientName)
                .UseSslProtocols(SslProtocols.Tls12);

            // Configure the ITokenClient to use the previous HttpClient.
            serviceCollection
                .AddClientCredentialsTokenClient(IamClientOptions.IamTokenClientName, options.TokenClientOptions)
                .UseHttpClientForBackchannel(IamClientOptions.IamTokenClientHttpClientName);

            // Configure the HttpClient with the ITokenClient for inserting tokens into the header.
            IHttpClientBuilder httpClientBuilder = serviceCollection
                .AddHttpClient(IamClientOptions.IamHttpClientName, c => c.BaseAddress = options.IamApiUri)
                .UseSslProtocols(SslProtocols.Tls12)
                .UseApiVersion(options.ApiVersion ?? "2019-09-01", null)
                .UseTokenClient(IamClientOptions.IamTokenClientName)
                .AddTypedClient<IIamClient, IamClient>();

            if (!string.IsNullOrWhiteSpace(options.ApiKey))
            {
                httpClientBuilder.UseHeader(options.ApiKeyHeaderName ?? "Subscription-Key", options.ApiKey);
            }

            return serviceCollection;
        }
    }
}
