namespace Main_Thread.Shared.ViewModels;

public class BusinessVm
{
    public int Id { get; set; }
    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    public string Password { get; set; }
    public string BusinessName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string StateEntityRegistration { get; set; }
    public string EmployerIdentificationNumber { get; set; }
    public string StreetAddressOne { get; set; }
    public string? StreetAddressTwo { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string ZipCode { get; set; }
    public string BusinessType { get; set; }
    public string? OtherBusinessType { get; set; }
}