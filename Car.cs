namespace CarInfoUK;

internal class Car
{
    public string? registrationNumber { get; set; }
    public string? taxStatus { get; set; }
    public string? taxDueDate { get; set; }
    public string? motStatus { get; set; }
    public string? make { get; set; }
    public int yearOfManufacture { get; set; }
    public int engineCapacity { get; set; }
    public int co2Emissions { get; set; }
    public string? fuelType { get; set; }
    public bool markedForExport { get; set; }
    public string? colour { get; set; }
    public string? typeApproval { get; set; }
    public string? dateOfLastV5CIssued { get; set; }
    public string? motExpiryDate { get; set; }
    public string? wheelplan { get; set; }
    public string? monthOfFirstRegistration { get; set; }

    public string GetDetails()
    {
        return "Registration number: " + registrationNumber + "\n" +

               "Make: " + make + "\n" +
               "Colour: " + colour + "\n" +

               "Mot: " + GetDate(motExpiryDate) + " - " + motStatus + "\n" +
               "Tax: " + GetDate(taxDueDate) + " - " + taxStatus + "\n" +

               "Year of manufacture: " + yearOfManufacture + "\n" +
               "First registration: " + GetDate(monthOfFirstRegistration) + "\n" +
               "Last V5C issued: " + GetDate(dateOfLastV5CIssued) + "\n" +

               "Fuel type: " + fuelType + "\n" +
               "Engine capacity: " + engineCapacity  + " cc" + "\n" +
               "CO₂ emissions: " + co2Emissions + " g/km" + "\n" +

               "Wheelplan: " + wheelplan + "\n" +
               "Type approval: " + typeApproval + "\n" +
               "Marked for export: " + markedForExport;
    }

    private string GetDate(string? input)
    {
        if (String.IsNullOrEmpty(input)) return "";

        string[] elements = input.Split('-');

        bool dayExist = elements.Length == 3;

        string month = "";
        switch (elements[1])
        {
            case "01": month = "Jan"; break;
            case "02": month = "Feb"; break;
            case "03": month = "Mar"; break;
            case "04": month = "Apr"; break;
            case "05": month = "May"; break;
            case "06": month = "Jun"; break;
            case "07": month = "Jul"; break;
            case "08": month = "Aug"; break;
            case "09": month = "Sep"; break;
            case "10": month = "Oct"; break;
            case "11": month = "Nov"; break;
            case "12": month = "Dec"; break;
        }

        return (dayExist ? elements[2] + " " : "") + month + " " + elements[0];
    }
}