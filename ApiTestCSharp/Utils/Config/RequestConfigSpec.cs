using System.Net;
using ApiTestCSharp.Utils.enums;
using RestAssured.Request;
using RestAssured.Request.Builders;
using static RestAssured.Dsl;
namespace ApiTestCSharp.Utils.Config;

public class RequestConfigSpec
{
    private static readonly Lazy<RequestConfigSpec> _instance =
        new Lazy<RequestConfigSpec>(() => new RequestConfigSpec());
    private RequestSpecBuilder RequestSpec = new();
    
    public RequestSpecBuilder Url(string baseUri, string path)
    {
        RequestSpec.WithBaseUri(baseUri);
        RequestSpec.WithBasePath(path);
        return RequestSpec;
    }

    public RequestSpecBuilder WithPort(int port)
    {
        return RequestSpec;
    }

/*



    public RequestSpecBuilder WithBasePath(string basePath)
    {
        this.BasePath = basePath; return this;
    }

    public RequestSpecBuilder WithTimeout(TimeSpan timeout)
    {
        this.Timeout = timeout; return this;
    }

    public RequestSpecBuilder WithQueryParam(string name, string value)
    {
        this.QueryParams[name] = value; return this;
    }

    public RequestSpecBuilder WithHeader(string name, string value)
    {
        this.Headers[name] = value; return this;
    } */
 }