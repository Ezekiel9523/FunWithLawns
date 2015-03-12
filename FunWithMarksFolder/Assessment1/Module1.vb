Module Module1
    Dim textColor As ConsoleColor
    Dim backGroundColor As ConsoleColor

    Class Profiles
        Public CName As String
        Public COwner As String
        Public CNumber As Integer
        Public CAddress As String
        Public Rate As Single
    End Class

    Dim Pro1 As New Profiles

    Sub Startup()

        'Startup
        Console.SetCursorPosition(23, 0)
        Console.WriteLine("Welcome to Fun With Lawns v0.1")
        Console.SetCursorPosition(18, 1)
        Console.WriteLine("Your all in one lawn management system.")
        Console.SetCursorPosition(25, 4)
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)

        'Change Later for Profiles
        Console.Clear()
        Console.WriteLine("No company information has been found, We'll set up a profile before we begin.")
        Console.WriteLine()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


    End Sub

    Sub ProfileSetup()

        Console.Clear()

        'Setting Up the profile
        Console.WriteLine("Here you need to enter the details for your new company profile.")
        Console.WriteLine()
        Console.Write("Company Name: ")
        Pro1.CName = Console.ReadLine
        Console.Write("Company Owner's Name: ")
        Pro1.COwner = Console.ReadLine
        Console.Write("Company Contact number: ")
        Pro1.CNumber = Console.readline
        Console.Write("Company Address: ")
        Pro1.CAddress = Console.ReadLine
        Console.Write("Company Hourly Rate: ")
        Pro1.Rate = Console.ReadLine
        Console.WriteLine()
        Console.WriteLine("Setup is Complete!")

    End Sub

    Sub Menu()

        Dim selection As Char

        Do

            'Draw up the menu
            Console.WriteLine("Welcome" & Pro1.COwner)
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine("Total completed hours: (PLACEHOLDER)")
            Console.WriteLine("Total income:          (PlACEHOLDER)")
            Console.WriteLine("-------------------------------------------------------")
            Console.WriteLine()
            Console.WriteLine("Select from one of the following menu options: ")
            Console.WriteLine(" (A) Add a booking")
            Console.WriteLine(" (B) View all incomplete bookings")
            Console.WriteLine(" (C) View all complete booking")
            Console.WriteLine(" (D) Check incomplete bookings for next 7 days")
            Console.WriteLine()
            Console.WriteLine(" (E) View incomplete booking details")
            Console.WriteLine(" (F) Edit incomplete booking details")
            Console.WriteLine()
            Console.WriteLine(" (G) Remove a booking")
            Console.WriteLine(" (H) Complete a booking")
            Console.WriteLine()
            Console.WriteLine(" (I) View business card")
            Console.WriteLine()
            Console.WriteLine(" (X) Exit")


            'Get the selected letter from the user
            selection = Console.ReadKey(True).KeyChar.ToString.ToUpper

            Select Case selection
                Case "A"
                    AddBookings()
                Case "B"
                    AllIncomplete()
                Case "C"
                    AllComplete()
                Case "D"
                    SevenDaysIncomplete()
                Case "E"
                    ViewIncomplete()
                Case "F"
                    EditIncomplete()
                Case "G"
                    RemoveBooking()
                Case "H"
                    CompleteBooking()
                Case "I"
                    BusinessCard()
            End Select

        Loop Until selection = "X"

    End Sub

    Sub AddBookings()

    End Sub

    Sub AllIncomplete()

    End Sub

    Sub AllComplete()

    End Sub

    Sub SevenDaysIncomplete()

    End Sub

    Sub ViewIncomplete()

    End Sub

    Sub EditIncomplete()

    End Sub

    Sub RemoveBooking()

    End Sub

    Sub CompleteBooking()

    End Sub

    Sub BusinessCard()

    End Sub

    Sub Main()

        Startup()
        ProfileSetup()
        Menu()
    End Sub

End Module
