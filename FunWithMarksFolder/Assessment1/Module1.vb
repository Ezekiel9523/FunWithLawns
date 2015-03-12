Module Module1

    Class Profiles
        Public CName As String
        Public COwner As String
        Public CNumber As Integer
        Public CAddress As String
        Public Rate As Single
    End Class

    Dim Pro1 As New Profiles

    Sub Menu()

        'Startup
        Console.SetCursorPosition(23, 0)
        Console.WriteLine("Welcome to Fun With Lawns v0.1")
        Console.SetCursorPosition(18, 1)
        Console.WriteLine("Your all in one lawn management system.")
        Console.SetCursorPosition(25, 4)
        Console.WriteLine("Press any key to continue...")
        Console.ReadLine()

        'Change Later for Profiles
        Console.Clear()
        Console.WriteLine("No company information has been found, We'll set up a profile before we begin.")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()


    End Sub

    Sub ProfileSetup()

        Console.Clear()

        'Setting Up the profile
        Console.WriteLine("Here you need to enter the details for your new company profile.")
        Console.WriteLine()
        Console.WriteLine("Company Name: ")
        Pro1.CName = Console.ReadLine
        Console.WriteLine("Company Owner's Name: ")
        Pro1.COwner = Console.ReadLine
        Console.WriteLine("Company Contact number: ")
        Pro1.CNumber = Console.readline
        Console.WriteLine("Company Address: ")
        Pro1.CAddress = Console.ReadLine
        Console.WriteLine("Company Hourly Rate: ")
        Pro1.Rate = Console.ReadLine

    End Sub
    Sub Main()

        Menu()
        ProfileSetup()

    End Sub

End Module
