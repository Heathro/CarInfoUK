using System.Net;
using System.Text.Json;
using RestSharp;

namespace CarInfoUK;

internal class Database
{
    private readonly string token;

    public Database(string token)
    {
        this.token = token;
    }

    public async Task<string> GetData(string number)
    {
        string url = "https://driver-vehicle-licensing.api.gov.uk/vehicle-enquiry/v1/vehicles";
        var client = new RestClient(url);
        var request = new RestRequest();

        request.AddHeader("x-api-key", this.token);
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("application/json", "{\n\t\"registrationNumber\":\"" + number.ToUpper() + "\"\n}", ParameterType.RequestBody);

        try
        {
            var response = await client.PostAsync(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    
                    var car = JsonSerializer.Deserialize<Car>(response.Content);
                    if (car == null) return "Error";

                    var details = car.GetDetails();
                    if (string.IsNullOrEmpty(details)) return "Error";

                    return details;

                case HttpStatusCode.BadRequest:
                    return "Bad Request";
                case HttpStatusCode.NotFound:
                    return "Vehicle Not Found";
                case HttpStatusCode.InternalServerError:
                    return "Internal Server Error";
                case HttpStatusCode.ServiceUnavailable:
                    return "Service Unavailable";
                default:
                    return "Error";
            }
        }
        catch
        {
            return "Type correct registration number";
        }
    }
}