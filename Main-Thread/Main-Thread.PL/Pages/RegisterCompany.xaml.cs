using System.Diagnostics;   // SHOULD be removed in production

namespace Main_Thread.PL.Pages;

public partial class RegisterCompany : ContentPage
{
    // TEMPORARY declaration and initialization
    List<string> companyInformation = new List<string>(new string[13]);

    public RegisterCompany()
	{
        InitializeComponent();

        // Ensure Picker has a default selection
        if (CategoryPicker.SelectedIndex == -1)
        {
            CategoryPicker.SelectedIndex = 0;
        }
    }

    // Functional methods - retrieve information from user input
    private void FirstNameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerFirstNameINPUT = FirstNameBox.Text;
        companyInformation[0] = COMPANYownerFirstNameINPUT;
    }

    private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerLastNameINPUT = LastNameBox.Text;
        companyInformation[1] = COMPANYownerLastNameINPUT;
    }

    private void BusinessNameBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYnameINPUT = BusinessNameBox.Text;
        companyInformation[2] = COMPANYnameINPUT;
    }

    private void ContactNumberBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerContactNumberINPUT = ContactNumberBox.Text;
        companyInformation[3] = COMPANYownerContactNumberINPUT;
    }

    private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYownerEmailINPUT = EmailBox.Text;
        companyInformation[4] = COMPANYownerEmailINPUT;
    }

    private void SERBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYSERNumberINPUT = SERBox.Text;
        companyInformation[5] = COMPANYSERNumberINPUT;
    }

    private void PINBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYemployerPININPUT = PINBox.Text;
        companyInformation[6] = COMPANYemployerPININPUT;
    }

    private void StreetAddressBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYstreetAddressOneINPUT = StreetAddressBox1.Text;
        companyInformation[7] = COMPANYstreetAddressOneINPUT;
    }

    private void StreetAddressBox2_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYstreetAddressTwoINPUT = StreetAddressBox2.Text;   // Can be null
        companyInformation[8] = COMPANYstreetAddressTwoINPUT;
    }

    private void CityBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYcityINPUT = CityBox.Text;
        companyInformation[9] = COMPANYcityINPUT;
    }

    private void ZipCodeBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYzipCodeINPUT = ZipCodeBox.Text;
        companyInformation[10] = COMPANYzipCodeINPUT;
    }

    private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CategoryPicker.SelectedItem != null)
        {
            string selectedCategory = CategoryPicker.SelectedItem.ToString();

            if (selectedCategory == "Others, please specify below")
            {
                OthersLabel.IsVisible = true;
                OthersBox.IsVisible = true;
            }
            else
            {
                OthersLabel.IsVisible = false;
                OthersBox.IsVisible = false;
                if (companyInformation[12] != null)
                {
                    companyInformation[12] = "";
                }
            }

            companyInformation[11] = selectedCategory;
        }
    }

    private void OthersBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        string COMPANYcategoryINPUT = OthersBox.Text;
        companyInformation[12] = COMPANYcategoryINPUT;
    }

    private void SubmitRegistratonButton_Clicked(object sender, EventArgs e)
    {
        // Run checks for each element HERE --[successful]--> register a company [write to database]
        // If needed move checks to BLL

        bool registrationSuccessful = false;

        // Write company register information to Debug window
        foreach (string information in companyInformation)
        {
            Debug.WriteLine(information);
        }

        if (registrationSuccessful) SuccessfulRegistrationCOMPANY.IsVisible = true;
    }

    // Design methods - enhance user experience
    private void FirstNameBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowOne.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void LastNameBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowOne.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void FirstNameBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowOne.BackgroundColor = Colors.White;
    }

    private void LastNameBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowOne.BackgroundColor = Colors.White;
    }

    private void BusinessNameBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowTwo.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void BusinessNameBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowTwo.BackgroundColor = Colors.White;
    }

    private void ContactNumberBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowThree.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void ContactNumberBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowThree.BackgroundColor = Colors.White;
    }

    private void EmailBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowFour.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void EmailBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowFour.BackgroundColor = Colors.White;
    }

    private void SERBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowFive.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void SERBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowFive.BackgroundColor = Colors.White;
    }

    private void PINBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowSix.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void PINBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowSix.BackgroundColor = Colors.White;
    }

    private void StreetAddressBox1_Focused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void StreetAddressBox1_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Colors.White;
    }

    private void StreetAddressBox2_Focused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void StreetAddressBox2_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Colors.White;
    }

    private void CityBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void CityBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Colors.White;
    }

    private void ZipCodeBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void ZipCodeBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowSeven.BackgroundColor = Colors.White;
    }

    private void CategoryPicker_Focused(object sender, FocusEventArgs e)
    {
        FormRowEight.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void CategoryPicker_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowEight.BackgroundColor = Colors.White;
    }

    private void OthersBox_Focused(object sender, FocusEventArgs e)
    {
        FormRowNine.BackgroundColor = Color.FromArgb("#f1f5ff");
    }

    private void OthersBox_Unfocused(object sender, FocusEventArgs e)
    {
        FormRowNine.BackgroundColor = Colors.White;
    }

}
